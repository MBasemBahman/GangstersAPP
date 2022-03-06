using GangstersAPP.Entity.ServiceProviderRequestEntity;
using GangstersAPP.ServiceEntity.ServiceProviderRequestEntity;

namespace GangstersAPP.API.Controllers.ServiceProviderRequestEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "ServiceProviderRequest")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServiceProviderRequestController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public ServiceProviderRequestController(
            DatabaseContext dataContext,
            UnitOfWork unitOfWork,
            IMapper mapper,
            EntityLocalizationService Localizer,
            IAccountService AccountService,
            IWebHostEnvironment environment,
            IOptions<AppSettings> appSettings)
        {
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Localizer = Localizer;
            _AccountService = AccountService;
            _Environment = environment;
            _appSettings = appSettings.Value;
            _StatusHandler = new StatusHandler(Localizer);
        }

        /// <summary>
        /// Get: Get Service Provider Requests
        /// </summary>
        [HttpGet]
        [Route(nameof(GetServiceProviderRequests))]
        public List<ServiceProviderRequestModel> GetServiceProviderRequests(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetServiceProviderRequests);
            List<ServiceProviderRequestModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<ServiceProviderRequest> Data = _UnitOfWork.ServiceProviderRequest.GetQuery(a => a.Fk_Account == account.Id,
                                                                                                           new List<string>()
                                                                                                           {
                                                                                                               "ServiceProviderClassification",
                                                                                                               "Governerate"
                                                                                                           });

                Data = OrderBy<ServiceProviderRequest>.OrderData(Data, paging.OrderBy);

                PagedList<ServiceProviderRequest> PagedData = PagedList<ServiceProviderRequest>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    foreach (ServiceProviderRequest item in PagedData)
                    {
                        item.ServiceProviderClassification = _UnitOfWork.ServiceProviderClassification.GetLang(item.ServiceProviderClassification);
                        item.Governerate = _UnitOfWork.Governerate.GetLang(item.Governerate);
                    }
                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<ServiceProviderRequest>.GetPagination(PagedData, paging, ActionName));

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }


        /// <summary>
        /// Get: Get Service Provider Request
        /// </summary>
        [HttpGet]
        [Route(nameof(GetServiceProviderRequest))]
        public ServiceProviderRequestModel GetServiceProviderRequest(
         [FromQuery] string Culture,
         [FromQuery] int id)
        {
            ServiceProviderRequestModel returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                ServiceProviderRequest Data = _UnitOfWork.ServiceProviderRequest.GetQuery(a => a.Id == id,
                                                                                                       new List<string>()
                                                                                                       {
                                                                                                               "ServiceProviderClassification",
                                                                                                               "Governerate",
                                                                                                               "ServiceProviderRequestAttachments"
                                                                                                       }).FirstOrDefault();



                if (Culture.ToLower() == "en")
                {
                    Data.ServiceProviderClassification = _UnitOfWork.ServiceProviderClassification.GetLang(Data.ServiceProviderClassification);
                    Data.Governerate = _UnitOfWork.Governerate.GetLang(Data.Governerate);
                }

                _Mapper.Map(Data, returnData);

                returnData.ServiceProviderRequestAttachments = new List<ServiceProviderRequestAttachmentModel>();

                _Mapper.Map(Data.ServiceProviderRequestAttachments, returnData.ServiceProviderRequestAttachments);

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }


        /// <summary>
        /// Post: Create Service Provider Request
        /// </summary>
        [HttpPost]
        [Route(nameof(CreateServiceProviderRequest))]
        public async Task<ServiceProviderRequestModel> CreateServiceProviderRequest(
            [FromQuery] string Culture,
            [FromBody] ServiceProviderRequestCreateModel model)
        {
            ServiceProviderRequestModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                ServiceProviderRequest DBData = new()
                {
                    Fk_Account = account.Id,
                    CreatedBy = account.FullName,
                };

                _Mapper.Map(model, DBData);


                _UnitOfWork.ServiceProviderRequest.CreateEntity(DBData);

                await _UnitOfWork.Save();

                ServiceProviderRequest createdData = _UnitOfWork.ServiceProviderRequest.GetQuery(a => a.Id == DBData.Id,
                                                                                                                     new List<string>()
                                                                                                                     {
                                                                                                               "ServiceProviderClassification",
                                                                                                               "Governerate"
                                                                                                                     }).FirstOrDefault();


                if (!string.IsNullOrEmpty(Culture) && Culture.ToLower() == "en")
                {
                    createdData.Governerate = _UnitOfWork.Governerate.GetLang(createdData.Governerate);
                    createdData.ServiceProviderClassification = _UnitOfWork.ServiceProviderClassification.GetLang(createdData.ServiceProviderClassification);
                }

                _Mapper.Map(createdData, returnData);

                Status = new Status(true);

            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }



        /// <summary>
        /// Post: Create Service Provider Request Attachments
        /// </summary>
        [HttpPost]
        [Route(nameof(CreateServiceProviderRequestAttachments))]
        public async Task<bool> CreateServiceProviderRequestAttachments(
            [FromQuery] string Culture,
            [FromQuery] int Fk_ServiceProviderRequest,
            [FromForm] List<ServiceProviderRequestAttachmentCreateModel> model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.ServiceProviderRequest.Any(a => a.Id == Fk_ServiceProviderRequest && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                ImgManager ImgManager = new(_Environment.WebRootPath);

                foreach (ServiceProviderRequestAttachmentCreateModel attachment in model)
                {
                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), attachment.File, "Uploud/ServiceProviderRequestAttachment");
                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        _UnitOfWork.ServiceProviderRequestAttachment.CreateEntity(new ServiceProviderRequestAttachment
                        {
                            Fk_ServiceProviderRequest = Fk_ServiceProviderRequest,
                            FileURL = FileURL,
                            FileLength = attachment.File.Length,
                            FileType = attachment.File.ContentType,
                            FileName = attachment.File.FileName,
                            CreatedBy = account.FullName,
                            Description = attachment.Description
                        });
                    }

                }

                await _UnitOfWork.Save();

                returnData = true;

                Status = new Status(true);

            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }
    }
}

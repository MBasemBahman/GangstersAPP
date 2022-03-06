namespace GangstersAPP.API.Controllers.BeneficiaryRequestEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "BeneficiaryRequest")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BeneficiaryRequestController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public BeneficiaryRequestController(
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
        /// Get: Get Beneficiary Requests
        /// </summary>
        [HttpGet]
        [Route(nameof(GetBeneficiaryRequests))]
        public List<BeneficiaryRequestModel> GetBeneficiaryRequests(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetBeneficiaryRequests);
            List<BeneficiaryRequestModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<BeneficiaryRequest> Data = _UnitOfWork.BeneficiaryRequest.GetQuery(a => a.Fk_Account == account.Id,
                                                                                                           new List<string>()
                                                                                                           {
                                                                                                               "BeneficiaryType",
                                                                                                               "Governerate"
                                                                                                           });

                Data = OrderBy<BeneficiaryRequest>.OrderData(Data, paging.OrderBy);

                PagedList<BeneficiaryRequest> PagedData = PagedList<BeneficiaryRequest>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    foreach (BeneficiaryRequest item in PagedData)
                    {
                        item.BeneficiaryType = _UnitOfWork.BeneficiaryType.GetLang(item.BeneficiaryType);
                        item.Governerate = _UnitOfWork.Governerate.GetLang(item.Governerate);
                    }
                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<BeneficiaryRequest>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Beneficiary Request
        /// </summary>
        [HttpGet]
        [Route(nameof(GetBeneficiaryRequest))]
        public BeneficiaryRequestModel GetBeneficiaryRequest(
         [FromQuery] string Culture,
         [FromQuery] int id)
        {
            BeneficiaryRequestModel returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                BeneficiaryRequest Data = _UnitOfWork.BeneficiaryRequest.GetQuery(a => a.Id == id,
                                                                                                       new List<string>()
                                                                                                       {
                                                                                                               "BeneficiaryType",
                                                                                                               "Governerate",
                                                                                                               "BeneficiaryRequestAttachments"
                                                                                                       }).FirstOrDefault();



                if (Culture.ToLower() == "en")
                {
                    Data.BeneficiaryType = _UnitOfWork.BeneficiaryType.GetLang(Data.BeneficiaryType);
                    Data.Governerate = _UnitOfWork.Governerate.GetLang(Data.Governerate);
                }

                _Mapper.Map(Data, returnData);

                returnData.BeneficiaryRequestAttachments = new List<BeneficiaryRequestAttachmentModel>();

                _Mapper.Map(Data.BeneficiaryRequestAttachments, returnData.BeneficiaryRequestAttachments);

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
        /// Post: Create Beneficiary Request
        /// </summary>
        [HttpPost]
        [Route(nameof(CreateBeneficiaryRequest))]
        public async Task<BeneficiaryRequestModel> CreateBeneficiaryRequest(
            [FromQuery] string Culture,
            [FromBody] BeneficiaryRequestCreateModel model)
        {
            BeneficiaryRequestModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                BeneficiaryRequest DBData = new()
                {
                    Fk_Account = account.Id,
                    CreatedBy = account.FullName,
                };

                _Mapper.Map(model, DBData);


                _UnitOfWork.BeneficiaryRequest.CreateEntity(DBData);

                await _UnitOfWork.Save();

                BeneficiaryRequest createdData = _UnitOfWork.BeneficiaryRequest.GetQuery(a => a.Id == DBData.Id,
                                                                                                                     new List<string>()
                                                                                                                     {
                                                                                                               "BeneficiaryType",
                                                                                                               "Governerate"
                                                                                                                     }).FirstOrDefault();


                if (!string.IsNullOrEmpty(Culture) && Culture.ToLower() == "en")
                {
                    createdData.Governerate = _UnitOfWork.Governerate.GetLang(createdData.Governerate);
                    createdData.BeneficiaryType = _UnitOfWork.BeneficiaryType.GetLang(createdData.BeneficiaryType);
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
        /// Post: Create Beneficiary Request Attachments
        /// </summary>
        [HttpPost]
        [Route(nameof(CreateBeneficiaryRequestAttachments))]
        public async Task<bool> CreateBeneficiaryRequestAttachments(
            [FromQuery] string Culture,
            [FromQuery] int Fk_BeneficiaryRequest,
            [FromForm] List<BeneficiaryRequestAttachmentCreateModel> model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.BeneficiaryRequest.Any(a => a.Id == Fk_BeneficiaryRequest && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                ImgManager ImgManager = new(_Environment.WebRootPath);

                foreach (BeneficiaryRequestAttachmentCreateModel attachment in model)
                {
                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), attachment.File, "Uploud/BeneficiaryRequestAttachment");
                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        _UnitOfWork.BeneficiaryRequestAttachment.CreateEntity(new BeneficiaryRequestAttachment
                        {
                            Fk_BeneficiaryRequest = Fk_BeneficiaryRequest,
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

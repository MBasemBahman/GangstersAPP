namespace GangstersAPP.API.Controllers.CHIAEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "CHIAData")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class CHIADataController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public CHIADataController(
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
        /// Get: Get Partners
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPartners))]
        public List<PartnerModel> GetPartners(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetPartners);
            List<PartnerModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<Partner> Data = _UnitOfWork.Partner.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<Partner>.OrderData(Data, paging.OrderBy);

                PagedList<Partner> PagedData = PagedList<Partner>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.Partner.GetLang(PagedData);
                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<Partner>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Service Providers
        /// </summary>
        [HttpGet]
        [Route(nameof(GetServiceProviders))]
        public List<ServiceProviderModel> GetServiceProviders(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] int Fk_ServiceProviderCategory,
            [FromQuery] int Fk_ServiceProviderAuthority,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetServiceProviders);
            List<ServiceProviderModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<GangstersAPP.Entity.CHIAEntity.ServiceProvider> Data = _UnitOfWork.ServiceProvider.GetQuery(a => (Fk_ServiceProviderCategory == 0 || a.Fk_ServiceProviderCategory == Fk_ServiceProviderCategory)
                                                                                           && (Fk_ServiceProviderAuthority == 0 || a.Fk_ServiceProviderAuthority == Fk_ServiceProviderAuthority)
                                                                                           && (string.IsNullOrEmpty(Search) ||
                                                                                                 a.Name.ToLower().Contains(Search.ToLower()))
                                                                                              , new List<string> { "ServiceProviderCategory", "ServiceProviderAuthority" });


                Data = OrderBy<GangstersAPP.Entity.CHIAEntity.ServiceProvider>.OrderData(Data, paging.OrderBy);

                PagedList<GangstersAPP.Entity.CHIAEntity.ServiceProvider> PagedData = PagedList<GangstersAPP.Entity.CHIAEntity.ServiceProvider>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.ServiceProvider.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                for (int i = 0; i < PagedData.Count; i++)
                {
                    returnData[i].ServiceProviderCategory = new ServiceProviderCategoryModel();

                    if (Culture.ToLower() == "en")
                    {
                        PagedData[i].ServiceProviderCategory = _UnitOfWork.ServiceProviderCategory.GetLang(PagedData[i].ServiceProviderCategory);
                        PagedData[i].ServiceProviderAuthority = _UnitOfWork.ServiceProviderAuthority.GetLang(PagedData[i].ServiceProviderAuthority);
                    }

                    _Mapper.Map(PagedData[i].ServiceProviderCategory, returnData[i].ServiceProviderCategory);
                    _Mapper.Map(PagedData[i].ServiceProviderAuthority, returnData[i].ServiceProviderAuthority);
                }

                Response.Headers.Add("X-Pagination", StatusHandler<GangstersAPP.Entity.CHIAEntity.ServiceProvider>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Tutorial Items
        /// </summary>
        [HttpGet]
        [Route(nameof(GetTutorialItems))]
        public List<TutorialItemModel> GetTutorialItems(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] int Fk_TutorialCategory,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetTutorialItems);
            List<TutorialItemModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<TutorialItem> Data = _UnitOfWork.TutorialItem.GetQuery(a => (Fk_TutorialCategory == 0 || a.Fk_TutorialCategory == Fk_TutorialCategory) && (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower()))
                                                                                        , new List<string> { "TutorialCategory" });


                Data = OrderBy<TutorialItem>.OrderData(Data, paging.OrderBy);

                PagedList<TutorialItem> PagedData = PagedList<TutorialItem>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.TutorialItem.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                for (int i = 0; i < PagedData.Count; i++)
                {
                    returnData[i].TutorialCategory = new TutorialCategoryModel();

                    if (Culture.ToLower() == "en")
                    {
                        PagedData[i].TutorialCategory = _UnitOfWork.TutorialCategory.GetLang(PagedData[i].TutorialCategory);
                    }
                    _Mapper.Map(PagedData[i].TutorialCategory, returnData[i].TutorialCategory);
                }

                Response.Headers.Add("X-Pagination", StatusHandler<TutorialItem>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Users Full Info Items
        /// </summary>
        [HttpGet]
        [Route(nameof(GetUserFullInfoItems))]
        public List<UserFullinfoItemModel> GetUserFullInfoItems(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetUserFullInfoItems);
            List<UserFullinfoItemModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<UserFullinfoItem> Data = _UnitOfWork.UserFullinfoItem.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Title.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<UserFullinfoItem>.OrderData(Data, paging.OrderBy);

                PagedList<UserFullinfoItem> PagedData = PagedList<UserFullinfoItem>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.UserFullinfoItem.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<UserFullinfoItem>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Service Provider Categories
        /// </summary>
        [HttpGet]
        [Route(nameof(GetServiceProviderCategories))]
        public List<ServiceProviderCategoryModel> GetServiceProviderCategories(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetServiceProviderCategories);
            List<ServiceProviderCategoryModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<ServiceProviderCategory> Data = _UnitOfWork.ServiceProviderCategory.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<ServiceProviderCategory>.OrderData(Data, paging.OrderBy);

                PagedList<ServiceProviderCategory> PagedData = PagedList<ServiceProviderCategory>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.ServiceProviderCategory.GetLang(PagedData);
                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<ServiceProviderCategory>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Tutorial Categories
        /// </summary>
        [HttpGet]
        [Route(nameof(GetTutorialCategories))]
        public List<TutorialCategoryModel> GetTutorialCategories(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetTutorialCategories);
            List<TutorialCategoryModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<TutorialCategory> Data = _UnitOfWork.TutorialCategory.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<TutorialCategory>.OrderData(Data, paging.OrderBy);

                PagedList<TutorialCategory> PagedData = PagedList<TutorialCategory>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.TutorialCategory.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<TutorialCategory>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Service Providers Authority
        /// </summary>
        [HttpGet]
        [Route(nameof(GetServiceProvidersAuthority))]
        public List<ServiceProviderAuthorityModel> GetServiceProvidersAuthority(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetServiceProvidersAuthority);
            List<ServiceProviderAuthorityModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<ServiceProviderAuthority> Data = _UnitOfWork.ServiceProviderAuthority.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower())));


                Data = OrderBy<ServiceProviderAuthority>.OrderData(Data, paging.OrderBy);

                PagedList<ServiceProviderAuthority> PagedData = PagedList<ServiceProviderAuthority>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.ServiceProviderAuthority.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<ServiceProviderAuthority>.GetPagination(PagedData, paging, ActionName));

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


namespace EConnectSocialMedia.API.Helpers
{
    public class StatusHandler
    {
        private readonly EntityLocalizationService _Localizer;

        public StatusHandler(EntityLocalizationService Localizer)
        {
            _Localizer = Localizer;
        }

        public string GetStatus(Status model)
        {
            model.ErrorMessage = EncodeManager.Base64Encode(model.ErrorMessage);
            return JsonSerializer.Serialize(model).Replace(",", @"\002C");
        }

        public Status SetException(Status status, Exception ex)
        {
            status.ErrorMessage = _Localizer.Get(ex.Message);
            status.ExceptionMessage = ex.Message;
            if (ex.InnerException != null)
            {
                status.ExceptionMessage = ex.InnerException.Message;
            }

            return status;
        }

        public string GetRefresh(string token)
        {
            Set_Refresh model = new()
            {
                RefreshToken = token,
                Expires = DateTime.UtcNow.AddDays(7).ToString("ddd, dd MMM yyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture)
            };
            return JsonSerializer.Serialize(model).Replace(",", @"\002C");
        }

        public string GetExpires()
        {
            return DateTime.UtcNow.AddMinutes(60).ToString("ddd, dd MMM yyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture).Replace(",", @"\002C");
        }
    }

    public class StatusHandler<T>
    {
        public static string GetPagination(PaginationMetaData<T> model)
        {
            return JsonSerializer.Serialize(model).Replace(",", @"\002C");
        }

        public static PaginationMetaData<T> PaginationMetaData(PagedList<T> pagedData, Paging paging, string actionName)
        {
            return new(pagedData)
            {
                PrevoisPageLink = pagedData.HasPrevious ? UrlLink(paging, actionName, paging.PageNumber - 1) : null,
                NextPageLink = pagedData.HasNext ? UrlLink(paging, actionName, paging.PageNumber + 1) : null
            };
        }

        public static string GetPagination(PagedList<T> pagedData, Paging paging, string actionName)
        {
            return GetPagination(PaginationMetaData(pagedData, paging, actionName));
        }

        private static string UrlLink(Paging paging, string actionName, int pageNumber)
        {
            return $"{actionName}?OrderBy={paging.OrderBy}&pageNumber={pageNumber}&PageSize={paging.PageSize}";
        }
    }
}

using Utilities;

namespace AsignioInternship.Data.LogWebResponse
{
    internal static class CountryDataModelExtensions
    {
        internal static LogWebResponseDataModel ToModel(this LogWebResponsePoco source)
        {
            if (null != source)
            {

                return new LogWebResponseDataModel
                {
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    Status = source.Status,
                    StatusCode = source.StatusCode,
                    StatusDescription = source.StatusDescription,
                    RedirectLocation = source.RedirectLocation,
                };
            }

            return null;
        }

        internal static LogWebResponsePoco ToPoco(this LogWebResponseDataModel source)
        {
            if (null != source)
            {

                return new LogWebResponsePoco
                {
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    Status = source.Status,
                    StatusCode = source.StatusCode,
                    StatusDescription = source.StatusDescription,
                    RedirectLocation = source.RedirectLocation,
                };
            }

            return null;
        }
    }
}
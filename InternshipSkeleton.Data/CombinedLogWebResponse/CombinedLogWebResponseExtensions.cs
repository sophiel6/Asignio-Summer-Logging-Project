using Utilities;

namespace AsignioInternship.Data.CombinedLogWebResponse
{
    internal static class CountryDataModelExtensions
    {
        internal static CombinedLogWebResponseDataModel ToModel(this CombinedLogWebResponsePoco source)
        {
            if (null != source)
            {
                return new CombinedLogWebResponseDataModel
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    Status = source.Status,
                    RedirectLocation = source.RedirectLocation,
                };
            }
            return null;
        }

        internal static CombinedLogWebResponsePoco ToPoco(this CombinedLogWebResponseDataModel source)
        {
            if (null != source)
            {
                return new CombinedLogWebResponsePoco
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    Status = source.Status,
                    RedirectLocation = source.RedirectLocation,
                };
            }
            return null;
        }
    }
}

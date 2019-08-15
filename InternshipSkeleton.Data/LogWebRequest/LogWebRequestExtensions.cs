using Utilities;

namespace AsignioInternship.Data.LogWebRequest
{
    internal static class CountryDataModelExtensions
    {
        internal static LogWebRequestDataModel ToModel(this LogWebRequestPoco source)
        {
            if (null != source)
            {
                return new LogWebRequestDataModel
                {
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    RawURL = source.RawURL,
                    Parameters = source.Parameters,
                    Important = source.Important,
                };
            }
            return null;
        }

        internal static LogWebRequestPoco ToPoco(this LogWebRequestDataModel source)
        {
            if (null != source)
            {
                return new LogWebRequestPoco
                {
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    RawURL = source.RawURL,
                    Parameters = source.Parameters,
                    Important = source.Important,
                };
            }
            return null;
        }
    }
}
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
                    //HostAddress = source.HostAddress,
                    //ServerIP = source.ServerIP,
                    RawURL = source.RawURL,
                    Parameters = source.Parameters,
                    //UserAgent = source.UserAgent,
                    //UserLanguages = source.UserLanguages,
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
                    //HostAddress = source.HostAddress,
                    //ServerIP = source.ServerIP,
                    RawURL = source.RawURL,
                    Parameters = source.Parameters,
                    //UserAgent = source.UserAgent,
                    //UserLanguages = source.UserLanguages,
                    Important = source.Important,
                };
            }

            return null;
        }
    }
}
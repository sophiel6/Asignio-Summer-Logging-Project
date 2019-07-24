using Utilities;

namespace AsignioInternship.Data.CombinedLogInfo
{
    internal static class CountryDataModelExtensions
    {
        internal static CombinedLogInfoDataModel ToModel(this CombinedLogInfoPoco source)
        {
            if (null != source)
            {

                return new CombinedLogInfoDataModel
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    Message = source.Message,
                    MethodName = source.MethodName,
                    Object = source.Object,
                    UserID = GuidMapper.Map(source.UserID),
                    Important = source.Important,
                };
            }

            return null;
        }

        internal static CombinedLogInfoPoco ToPoco(this CombinedLogInfoDataModel source)
        {
            if (null != source)
            {
                return new CombinedLogInfoPoco
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    Message = source.Message,
                    MethodName = source.MethodName,
                    Object = source.Object,
                    UserID = GuidMapper.Map(source.UserID),
                    Important = source.Important,
                };
            }

            return null;
        }
    }
}

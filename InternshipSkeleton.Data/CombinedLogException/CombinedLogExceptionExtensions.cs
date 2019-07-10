using Utilities;

namespace AsignioInternship.Data.CombinedLogException
{
    internal static class CountryDataModelExtensions
    {
        internal static CombinedLogExceptionDataModel ToModel(this CombinedLogExceptionPoco source)
        {
            if (null != source)
            {

                return new CombinedLogExceptionDataModel
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    Message = source.Message,
                    MethodName = source.MethodName,
                    Source = source.Source,
                    StackTrace = source.StackTrace,

    };
            }

            return null;
        }

        internal static CombinedLogExceptionPoco ToPoco(this CombinedLogExceptionDataModel source)
        {
            if (null != source)
            {
                return new CombinedLogExceptionPoco
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    Message = source.Message,
                    MethodName = source.MethodName,
                    Source = source.Source,
                    StackTrace = source.StackTrace,
                };
            }

            return null;
        }
    }
}

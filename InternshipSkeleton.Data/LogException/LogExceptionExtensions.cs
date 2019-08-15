using Utilities;

namespace AsignioInternship.Data.LogException
{
    internal static class CountryDataModelExtensions
    {
        internal static LogExceptionDataModel ToModel(this LogExceptionPoco source)
        {
            if (null != source)
            {
                return new LogExceptionDataModel
                {
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

        internal static LogExceptionPoco ToPoco(this LogExceptionDataModel source)
        {
            if (null != source)
            {
                return new LogExceptionPoco
                {
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

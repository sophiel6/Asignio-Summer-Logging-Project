﻿using Utilities;

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
                    UserID = GuidMapper.Map(source.UserID),
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    Message = source.Message,
                    MethodName = source.MethodName,
                    Source = source.Source,
                    StackTrace = source.StackTrace,
                    Important = source.Important,
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
                    UserID = GuidMapper.Map(source.UserID),
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    Message = source.Message,
                    MethodName = source.MethodName,
                    Source = source.Source,
                    StackTrace = source.StackTrace,
                    Important = source.Important,
                };
            }
            return null;
        }
    }
}

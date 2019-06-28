using Utilities;

namespace AsignioInternship.Data.LogInfo
{
    internal static class CountryDataModelExtensions
    {
        internal static LogInfoDataModel ToModel(this LogInfoPoco source)
        {
            if (null != source)
            {

                return new LogInfoDataModel
                {
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    Message = source.Message,
                    MethodName = source.MethodName,
                    Object = source.Object,
                    ID = GuidMapper.Map(source.ID),
                };
            }

            return null;
        }

        internal static LogInfoPoco ToPoco(this LogInfoDataModel source)
        {
            if (null != source)
            {

                return new LogInfoPoco
                {
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    Message = source.Message,
                    MethodName = source.MethodName,
                    Object = source.Object,
                    ID = GuidMapper.Map(source.ID),
                };
            }

            return null;
        }
    }
}
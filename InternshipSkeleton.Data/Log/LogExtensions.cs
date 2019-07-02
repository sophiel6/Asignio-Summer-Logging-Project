using Utilities;

namespace AsignioInternship.Data.Log
{
    internal static class CountryDataModelExtensions
    {
        internal static LogDataModel ToModel(this LogPoco source)
        {
            if (null != source)
            {

                return new LogDataModel
                {
                    TimeStamp = source.TimeStamp,
                    LogID = GuidMapper.Map(source.LogID),
                    UserID = GuidMapper.Map(source.UserID),
                    Message = source.Message,
                    Username = source.Username,
                    Source = source.Source,
                    Level = source.Level,
                };
            }

            return null;
        }

        internal static LogPoco ToPoco(this LogDataModel source)
        {
            if (null != source)
            {

                return new LogPoco
                {
                    TimeStamp = source.TimeStamp,
                    LogID = GuidMapper.Map(source.LogID),
                    UserID = GuidMapper.Map(source.UserID),
                    Message = source.Message,
                    Username = source.Username,
                    Source = source.Source,
                    Level = source.Level,
                };
            }

            return null;
        }
    }
}
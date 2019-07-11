using Utilities;

namespace AsignioInternship.Data.CombinedLog
{
    internal static class CountryDataModelExtensions
    {
        internal static CombinedLogDataModel ToModel(this CombinedLogPoco source)
        {
            if (null != source)
            {

                return new CombinedLogDataModel
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    LogID = GuidMapper.Map(source.LogID),
                    Message = source.Message,
                    Level = source.Level,
                    Source = source.Source,
                };
            }

            return null;
        }

        internal static CombinedLogPoco ToPoco(this CombinedLogDataModel source)
        {
            if (null != source)
            {
                return new CombinedLogPoco
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    LogID = GuidMapper.Map(source.LogID),
                    Message = source.Message,
                    Level = source.Level,
                    Source = source.Source,
                };
            }

            return null;
        }
    }
}

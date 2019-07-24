using Utilities;

namespace AsignioInternship.Data.LogMySql
{
    internal static class CountryDataModelExtensions
    {
        internal static LogMySqlDataModel ToModel(this LogMySqlPoco source)
        {
            if (null != source)
            {

                return new LogMySqlDataModel
                {
                    DateTimeStamp = source.DateTimeStamp,
                    Message = source.Message,
                    Function = source.Function,
                    Type = source.Type,
                    Important = source.Important,
                };
            }
            return null;
        }

        internal static LogMySqlPoco ToPoco(this LogMySqlDataModel source)
        {
            if (null != source)
            {
                return new LogMySqlPoco
                {
                    DateTimeStamp = source.DateTimeStamp,
                    Message = source.Message,
                    Function = source.Function,
                    Type = source.Type,
                    Important = source.Important,
                };
            }
            return null;
        }
    }
}
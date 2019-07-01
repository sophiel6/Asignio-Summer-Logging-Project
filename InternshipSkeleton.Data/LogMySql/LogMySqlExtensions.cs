﻿using Utilities;

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
                    TimeStamp = source.TimeStamp,
                    Message = source.Message,
                    Function = source.Function,
                    Type = source.Type,
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
                    TimeStamp = source.TimeStamp,
                    Message = source.Message,
                    Function = source.Function,
                    Type = source.Type,
                };
            }

            return null;
        }
    }
}
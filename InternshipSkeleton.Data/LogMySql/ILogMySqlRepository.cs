using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogMySql
{
    public interface ILogMySqlRepository
    {
        LogMySqlDataModel GetFromUserID(Guid UserID);
        //LogExceptionDataModel Insert(LogExceptionDataModel dataModel);

        IEnumerable<LogMySqlDataModel> GetAll();
    }
}
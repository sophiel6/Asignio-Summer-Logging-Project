using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogException
{
    public interface ILogExceptionRepository
    {
        LogExceptionDataModel GetFromUserID(Guid UserID);
        //LogExceptionDataModel Insert(LogExceptionDataModel dataModel);

        IEnumerable<LogExceptionDataModel> GetAll();
    }
}
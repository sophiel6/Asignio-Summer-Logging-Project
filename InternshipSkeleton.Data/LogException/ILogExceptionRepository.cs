using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogException
{
    public interface ILogExceptionRepository
    {
        LogExceptionDataModel GetFromUserID(Guid UserID);
        //LogExceptionDataModel Insert(LogExceptionDataModel dataModel);

        IEnumerable<LogExceptionDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogExceptionDataModel> GetAll();

        PagedDataModelCollection<LogExceptionDataModel> PageLogException(string nameSearchPattern, int pageSize, 
            int pageNumber, string sortColumn, string sortDirection);

    }
}
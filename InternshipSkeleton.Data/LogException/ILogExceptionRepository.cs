using AsignioInternship.Data.CombinedLogException;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogException
{
    public interface ILogExceptionRepository
    {
        LogExceptionDataModel GetFromUserID(Guid UserID);

        IEnumerable<LogExceptionDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogExceptionDataModel> GetAll();

        PagedDataModelCollection<CombinedLogExceptionDataModel> CombinedPageLogException(string nameSearchPattern, 
                                            int pageSize, int pageNumber, string sortColumn, string sortDirection);

        //PagedDataModelCollection<LogExceptionDataModel> PageLogException(string nameSearchPattern, int pageSize, 
        //int pageNumber, string sortColumn, string sortDirection);
        //IEnumerable<CombinedLogExceptionDataModel> ExampleQuery();

    }
}
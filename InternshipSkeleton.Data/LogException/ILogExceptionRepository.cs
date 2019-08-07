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

        PagedDataModelCollection<CombinedLogExceptionDataModel> CombinedPageLogException(int pageSize, int pageNumber, 
                                 string sortColumn, string sortDirection, Dictionary<string,string> searchDictionary);

        int Update(CombinedLogExceptionDataModel LogToUpdate, string username);
        Guid GetUserIDFromUsername(string username);
        int UndoUpdate(CombinedLogExceptionDataModel logToUpdate);
    }
}
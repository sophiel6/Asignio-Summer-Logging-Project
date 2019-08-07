using AsignioInternship.Data.CombinedLog;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.Log
{
    public interface ILogRepository
    {
        PagedDataModelCollection<CombinedLogDataModel> CombinedPageLog(int pageSize, int pageNumber, string sortColumn, string sortDirection, Dictionary<string, string> searchDictionary);
        int UndoUpdate(CombinedLogDataModel logToUpdate);
        int Update(CombinedLogDataModel LogToUpdate, string username);
        Guid GetUserIDFromUsername(string username);
    }
}
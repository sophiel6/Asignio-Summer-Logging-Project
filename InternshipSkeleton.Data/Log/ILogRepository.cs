using AsignioInternship.Data.CombinedLog;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.Log
{
    public interface ILogRepository
    {
        PagedDataModelCollection<CombinedLogDataModel> CombinedPageLog(string nameSearchPattern,
                        string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection);
        int UndoUpdate(CombinedLogDataModel logToUpdate);
        int Update(CombinedLogDataModel LogToUpdate, string username);
        Guid GetUserIDFromUsername(string username);
    }
}
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogWebRequest
{
    public interface ILogWebRequestRepository
    {
        PagedDataModelCollection<LogWebRequestDataModel> PageLogWebRequest(string nameSearchPattern,
                        string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection);
        int Update(LogWebRequestDataModel LogToUpdate, string username);
        int UndoUpdate(LogWebRequestDataModel LogToUpdate);
        Guid GetUserIDFromUsername(string username);
    }
}
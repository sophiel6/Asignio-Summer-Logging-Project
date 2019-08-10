using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogWebRequest
{
    public interface ILogWebRequestRepository
    {
        PagedDataModelCollection<LogWebRequestDataModel> PageLogWebRequest(int pageSize, int pageNumber, string sortColumn, string sortDirection, Dictionary<string,string> searchDictionary);
        int Update(LogWebRequestDataModel LogToUpdate, string username);
        int UndoUpdate(LogWebRequestDataModel LogToUpdate);
        Guid GetUserIDFromUsername(string username);
    }
}
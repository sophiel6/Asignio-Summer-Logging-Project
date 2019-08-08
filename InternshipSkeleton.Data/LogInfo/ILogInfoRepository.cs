using AsignioInternship.Data.CombinedLogInfo;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogInfo
{
    public interface ILogInfoRepository
    {
        PagedDataModelCollection<CombinedLogInfoDataModel> CombinedPageLogInfo(int pageSize, int pageNumber, string sortColumn, string sortDirection, Dictionary<string,string> searchDictionary);

        int Update(CombinedLogInfoDataModel LogToUpdate, string username);

        int UndoUpdate(CombinedLogInfoDataModel LogToUpdate);

        Guid GetUserIDFromUsername(string username);
    }
}
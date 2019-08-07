using AsignioInternship.Data.CombinedLogControllerAction;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogControllerAction
{
    public interface ILogControllerActionRepository
    {
        PagedDataModelCollection<CombinedLogControllerActionDataModel> CombinedPageLogControllerAction(int pageSize, int pageNumber, string sortColumn, string sortDirection, Dictionary<string,string> searchDict);

        int Update(CombinedLogControllerActionDataModel LogToUpdate, string username);

        int UndoUpdate(CombinedLogControllerActionDataModel LogToUpdate);

        Guid GetUserIDFromUsername(string username);
    }
}

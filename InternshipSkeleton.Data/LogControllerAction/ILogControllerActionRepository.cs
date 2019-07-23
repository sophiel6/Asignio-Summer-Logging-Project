using AsignioInternship.Data.CombinedLogControllerAction;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogControllerAction
{
    public interface ILogControllerActionRepository
    {
        PagedDataModelCollection<CombinedLogControllerActionDataModel> CombinedPageLogControllerAction(string nameSearchPattern,
                                     string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection);

        int Update(CombinedLogControllerActionDataModel LogToUpdate, string username);

        int UndoUpdate(CombinedLogControllerActionDataModel LogToUpdate);

        Guid GetUserIDFromUsername(string username);
    }
}

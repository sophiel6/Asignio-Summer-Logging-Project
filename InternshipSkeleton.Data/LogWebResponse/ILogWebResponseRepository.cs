using AsignioInternship.Data.CombinedLogWebResponse;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogWebResponse
{
    public interface ILogWebResponseRepository
    {
        PagedDataModelCollection<CombinedLogWebResponseDataModel> CombinedPageLogWebResponse(string nameSearchPattern,
                       string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection);

        int Update(CombinedLogWebResponseDataModel LogToUpdate, string username);

        int UndoUpdate(CombinedLogWebResponseDataModel LogToUpdate);

        Guid GetUserIDFromUsername(string username);
    }
}
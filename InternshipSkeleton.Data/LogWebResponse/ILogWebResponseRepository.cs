using AsignioInternship.Data.CombinedLogWebResponse;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogWebResponse
{
    public interface ILogWebResponseRepository
    {
        LogWebResponseDataModel GetFromUserID(Guid UserID);

        IEnumerable<LogWebResponseDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogWebResponseDataModel> GetAll();

        PagedDataModelCollection<CombinedLogWebResponseDataModel> CombinedPageLogWebResponse(string nameSearchPattern,
                       string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection);
    }
}
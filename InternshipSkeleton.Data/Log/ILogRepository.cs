using AsignioInternship.Data.CombinedLog;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.Log
{
    public interface ILogRepository
    {
        LogDataModel GetFromUserID(Guid UserID);

        IEnumerable<LogDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogDataModel> GetAll();

        PagedDataModelCollection<CombinedLogDataModel> CombinedPageLog(string nameSearchPattern,
                        string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection);
    }
}
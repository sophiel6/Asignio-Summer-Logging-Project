using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogMySql
{
    public interface ILogMySqlRepository
    {
        IEnumerable<LogMySqlDataModel> GetAll();

        PagedDataModelCollection<LogMySqlDataModel> PageLogMySql(string nameSearchPattern, string searchColumn,
                                                int pageSize, int pageNumber, string sortColumn, string sortDirection);
    }
}
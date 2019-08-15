using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogMySql
{
    public interface ILogMySqlRepository
    {
        PagedDataModelCollection<LogMySqlDataModel> PageLogMySql(int pageSize, int pageNumber, string sortColumn, string sortDirection, Dictionary<string,string> searchDict);

        int Update(LogMySqlDataModel LogToUpdate, string username);

        int UndoUpdate(LogMySqlDataModel LogToUpdate);

        Guid GetUserIDFromUsername(string username);
    }
}
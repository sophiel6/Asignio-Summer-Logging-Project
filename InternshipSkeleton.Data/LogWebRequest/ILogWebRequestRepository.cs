using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogWebRequest
{
    public interface ILogWebRequestRepository
    {
        LogWebRequestDataModel GetFromUserID(Guid UserID);
        //LogExceptionDataModel Insert(LogExceptionDataModel dataModel);

        IEnumerable<LogWebRequestDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogWebRequestDataModel> GetAll();

        PagedDataModelCollection<LogWebRequestDataModel> PageLogWebRequest(string nameSearchPattern, 
                            int pageSize, int pageNumber, string sortColumn, string sortDirection);

    }
}
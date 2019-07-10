using AsignioInternship.Data.CombinedLogControllerAction;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogControllerAction
{
    public interface ILogControllerActionRepository
    {
        LogControllerActionDataModel GetFromUserID(Guid UserID);
        //LogExceptionDataModel Insert(LogExceptionDataModel dataModel);

        IEnumerable<LogControllerActionDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogControllerActionDataModel> GetAll();

        PagedDataModelCollection<CombinedLogControllerActionDataModel> CombinedPageLogControllerAction(string nameSearchPattern, int pageSize, int pageNumber, string sortColumn, string sortDirection);

    }
}

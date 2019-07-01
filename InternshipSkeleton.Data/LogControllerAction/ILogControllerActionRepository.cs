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
    }
}

using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogWebRequest
{
    public interface ILogWebRequestRepository
    {
        LogWebRequestDataModel GetFromUserID(Guid UserID);
        //LogExceptionDataModel Insert(LogExceptionDataModel dataModel);

        IEnumerable<LogWebRequestDataModel> GetAll();
    }
}
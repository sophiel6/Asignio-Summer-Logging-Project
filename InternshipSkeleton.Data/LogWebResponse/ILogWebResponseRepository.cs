using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogWebResponse
{
    public interface ILogWebResponseRepository
    {
        LogWebResponseDataModel GetFromUserID(Guid UserID);
        //LogExceptionDataModel Insert(LogExceptionDataModel dataModel);

        IEnumerable<LogWebResponseDataModel> GetAll();
    }
}
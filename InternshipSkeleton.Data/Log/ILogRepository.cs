using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.Log
{
    public interface ILogRepository
    {
        LogDataModel GetFromUserID(Guid UserID);

        IEnumerable<LogDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogDataModel> GetAll();
    }
}
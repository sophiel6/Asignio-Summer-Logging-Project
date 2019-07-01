using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogInfo
{
    public interface ILogInfoRepository
    {
        LogInfoDataModel GetFromUserID(Guid UserID);
        //LogExceptionDataModel Insert(LogExceptionDataModel dataModel);

        IEnumerable<LogInfoDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogInfoDataModel> GetAll();
    }
}
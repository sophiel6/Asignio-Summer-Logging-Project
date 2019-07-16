using AsignioInternship.Data.CombinedLogInfo;
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

        PagedDataModelCollection<CombinedLogInfoDataModel> CombinedPageLogInfo(string nameSearchPattern,
                                       string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection);
    }
}
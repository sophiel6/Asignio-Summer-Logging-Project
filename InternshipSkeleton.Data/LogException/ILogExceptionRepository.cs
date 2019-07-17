﻿using AsignioInternship.Data.CombinedLogException;
using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.LogException
{
    public interface ILogExceptionRepository
    {
        LogExceptionDataModel GetFromUserID(Guid UserID);

        IEnumerable<LogExceptionDataModel> GetAllFromUserID(Guid UserID);

        IEnumerable<LogExceptionDataModel> GetAll();

        PagedDataModelCollection<CombinedLogExceptionDataModel> CombinedPageLogException(string nameSearchPattern, string searchColumn,
                                            int pageSize, int pageNumber, string sortColumn, string sortDirection);

        void Update(CombinedLogExceptionDataModel LogToUpdate, Guid UserID);
        Guid GetUserIDFromUsername(string username);
    }
}
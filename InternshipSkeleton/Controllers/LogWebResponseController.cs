﻿using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogWebResponse;
using AsignioInternship.Data.LogWebResponse;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogWebResponseController : Controller
    {
        public LogWebResponseController(ILogWebResponseRepository logRepository)
        {
            m_logRepository = (logRepository != null) ? logRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string searchBy, string searchInput, string sortBy)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string searchInfo = searchInput ?? "";
            string searchColumn = searchBy ?? "";
            PagedDataModelCollection<CombinedLogWebResponseDataModel> result = m_logRepository.CombinedPageLogWebResponse(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogWebResponseDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logRepository.Update(logToUpdate, username);

            if (updatePerformed == 1) //update successfull
            {
                string success = "Successfully marked as important";
                return Json(success);
            }
            else //update failed 
            {
                string failed = "Email entered by the user was not found in user database";
                return Json(failed);
            }
        }

        [HttpPost]
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogWebResponseDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logRepository.UndoUpdate(logToUpdate);

            if (updatePerformed == 1)
            {
                string success = "Successfully unmarked as important";
                return Json(success);
            }
            else
            {
                string failed = "Error";
                return Json(failed);
            }
        }

        private readonly ILogWebResponseRepository m_logRepository;
    }
}
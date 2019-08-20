﻿using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogControllerAction;
using AsignioInternship.Data.LogControllerAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogControllerActionController : Controller
    {
        private readonly ILogControllerActionRepository m_logControllerActionRepository;

        public LogControllerActionController(ILogControllerActionRepository logControllerActionRepository)
        {
            m_logControllerActionRepository = (logControllerActionRepository != null) ? logControllerActionRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string sortBy, string sortDir, Dictionary<string, string> searchDictionary)
        {
            int pageNum = id ?? 1;
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string sortDirection = sortDir ?? "ASC";
            Dictionary<string, string> searchDict;

            if (searchDictionary.Keys.ElementAt(0) == "controller" || searchDictionary == null)
            { searchDict = new Dictionary<string, string>() { { "Default", "" } }; }
            else
            { searchDict = searchDictionary; }

            PagedDataModelCollection<CombinedLogControllerActionDataModel> result = m_logControllerActionRepository.CombinedPageLogControllerAction(pageSize, pageNum, sortColumn, sortDirection, searchDict);
            return View(result);
        }

        public ActionResult SearchIndex(int? id, string sortBy, string sortDir, Dictionary<string, string> searchDictionary)
        {
            int pageNum = id ?? 1;
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string sortDirection = sortDir ?? "ASC";
            Dictionary<string, string> searchDict;

            if (searchDictionary.Keys.ElementAt(0) == "controller" || searchDictionary == null)
            { searchDict = new Dictionary<string, string>() { { "Default", "" } }; }
            else
            { searchDict = searchDictionary; }

            PagedDataModelCollection<CombinedLogControllerActionDataModel> result = m_logControllerActionRepository.CombinedPageLogControllerAction(pageSize, pageNum, sortColumn, sortDirection, searchDict);
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogControllerActionDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logControllerActionRepository.Update(logToUpdate, username);

            if (updatePerformed == 1) //update successful
            {
                string success = "Successfully marked as important";
                return Json(new { IsCreated = true, Content = success });
            }
            else //update failed - generally because the user entered email was not in the user database 
            {
                return Json(new { IsCreated = false, ErrorMessage = "Email entered by the user was not found in user database" });
            }
        }

        [HttpPost]
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogControllerActionDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logControllerActionRepository.UndoUpdate(logToUpdate);

            if (updatePerformed == 1)
            {
                string success = "Successfully unmarked as important";
                return Json(new { IsCreated = true, Content = success });
            }
            else
            {
                return Json(new { IsCreated = false, ErrorMessage = "Error" });
            }
        }

        public ActionResult AdvancedSearch()
        {
            return View();
        }
    }
}
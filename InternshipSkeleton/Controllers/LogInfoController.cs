using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogInfo;
using AsignioInternship.Data.LogInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogInfoController : Controller
    {
        private readonly ILogInfoRepository m_logInfoRepository;

        public LogInfoController(ILogInfoRepository logInfoRepository)
        {
            m_logInfoRepository = (logInfoRepository != null) ? logInfoRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string sortBy, string sortDir, Dictionary<string,string> searchDictionary)
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

            PagedDataModelCollection<CombinedLogInfoDataModel> result = m_logInfoRepository.CombinedPageLogInfo(pageSize, pageNum, sortColumn, sortDirection, searchDict);
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

            PagedDataModelCollection<CombinedLogInfoDataModel> result = m_logInfoRepository.CombinedPageLogInfo(pageSize, pageNum, sortColumn, sortDirection, searchDict);
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogInfoDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logInfoRepository.Update(logToUpdate, username);

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
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogInfoDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logInfoRepository.UndoUpdate(logToUpdate);

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
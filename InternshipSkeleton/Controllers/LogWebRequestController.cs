using AsignioInternship.Data;
using AsignioInternship.Data.LogWebRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogWebRequestController : Controller
    {
        public LogWebRequestController(ILogWebRequestRepository logWebRequestRepository)
        {
            m_logWebRequestRepository = (logWebRequestRepository != null) ? logWebRequestRepository : throw new ArgumentNullException();
        }
        
        public ActionResult Index(int? id, string sortBy, string sortDir, Dictionary<string, string> searchDictionary)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string sortDirection = sortDir ?? "ASC";
            var searchD = new Dictionary<string, string>() { { "Default", "" } };

            Dictionary<string, string> searchDict;
            if (searchDictionary.Keys.ElementAt(0) == "controller" || searchDictionary == null)
            { searchDict = searchD; }
            else
            { searchDict = searchDictionary; }
            PagedDataModelCollection<LogWebRequestDataModel> result = m_logWebRequestRepository.PageLogWebRequest(pageSize, pageNum, sortColumn, sortDirection, searchDict);
            return View(result);
        }

        public ActionResult SearchIndex(int? id, string sortBy, string sortDir, Dictionary<string, string> searchDictionary)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string sortDirection = sortDir ?? "ASC";
            var searchD = new Dictionary<string, string>() { { "Default", "" } };

            Dictionary<string, string> searchDict;
            if (searchDictionary.Keys.ElementAt(0) == "controller" || searchDictionary == null)
            { searchDict = searchD; }
            else
            { searchDict = searchDictionary; }
            PagedDataModelCollection<LogWebRequestDataModel> result = m_logWebRequestRepository.PageLogWebRequest(pageSize, pageNum, sortColumn, sortDirection, searchDict);
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]LogWebRequestDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logWebRequestRepository.Update(logToUpdate, username);

            if (updatePerformed == 1) //update successfull
            {
                string success = "Successfully marked as important";
                return Json(new { IsCreated = true, Content = success });
            }
            else //update failed 
            {
                return Json(new { IsCreated = false, ErrorMessage = "Email entered by the user was not found in user database" });
            }
        }

        [HttpPost]
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]LogWebRequestDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logWebRequestRepository.UndoUpdate(logToUpdate);

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

        private readonly ILogWebRequestRepository m_logWebRequestRepository;
    }
}
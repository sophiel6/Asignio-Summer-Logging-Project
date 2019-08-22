using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogException;
using AsignioInternship.Data.LogException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogExceptionController : Controller
    {
        private readonly ILogExceptionRepository m_logExceptionRepository;

        public LogExceptionController(ILogExceptionRepository logExceptionRepository)
        {
            m_logExceptionRepository = (logExceptionRepository != null) ? logExceptionRepository : throw new ArgumentNullException();
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

            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(pageSize, 
                                                                                        pageNum, sortColumn, sortDirection, searchDict);
            return View(result);
        }

        public ActionResult SearchIndex(int? id, Dictionary<string,string> searchDictionary, string sortBy, string sortDir)
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

            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(pageSize,
                                                                                        pageNum, sortColumn, sortDirection, searchDict); 
            return View(result);
        }
        
        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogExceptionDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logExceptionRepository.Update(logToUpdate, username); 
            
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
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogExceptionDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logExceptionRepository.UndoUpdate(logToUpdate);

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

/* To do:
 * -comment code?
 * 
 * Problems: 
 * -have to click some buttons multiple times for them to work (submit on AdvancedSearch, jump to page, etc.)
 * -modals don't close when you click outside
 * 
 */

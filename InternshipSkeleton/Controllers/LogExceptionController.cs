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
        public LogExceptionController(ILogExceptionRepository logExceptionRepository)
        {
            m_logExceptionRepository = (logExceptionRepository != null) ? logExceptionRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string sortBy, string sortDir, Dictionary<string,string> searchDictionary)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string sortDirection = sortDir ?? "ASC";
            var searchD = new Dictionary<string, string>()
            {
                {"EmailAddress", ""  },
                {"TimeStamp", "" },
                {"Message", "" },
                {"MethodName", "" },
                {"Source", "" },
                {"StackTrace", "" }
             };

            Dictionary<string, string> searchDict; 
            if (searchDictionary.Keys.ElementAt(0) == "controller" || searchDictionary==null)
            { searchDict = searchD; }
            else
            { searchDict = searchDictionary; }
            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(pageSize, 
                                                                                        pageNum, sortColumn, sortDirection, searchDict);
            return View(result);
        }

         public ActionResult SearchIndex(int? id, Dictionary<string,string> searchDictionary, string sortBy, string sortDir)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string sortDirection = sortDir ?? "ASC";
            var searchD = new Dictionary<string, string>()
            {
                {"EmailAddress", ""  },
                {"TimeStamp", "" },
                {"Message", "" },
                {"MethodName", "" },
                {"Source", "" },
                {"StackTrace", "" }
             };

            Dictionary<string, string> searchDict;
            if (searchDictionary.Keys.ElementAt(0) == "controller" || searchDictionary == null)
            { searchDict = searchD; }
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

        private readonly ILogExceptionRepository m_logExceptionRepository;
    }
}

/*
 * To do - general
 * -make the active tab in the navbar appear selected
 * -fix the overlap of the navbar and the page - and add a title to each page 
 * 
 * -combine PageLogException and NewPageLogException functions in repository 
 * -add stuff in Page repository function for stringing clauses together 
 * -implement all searching (basic and advanced) using the search Dictionary (eventually remove searchBy and searchInput from DataModelCollection)
 * 
 * Controller - change Index, add SearchIndex and AdvancedSearch
 * Repository - change CombinedPage method
 * IRepository - change CombinedPage method signature
 * Views - update Index, add Advanced Search, add SearchIndex 
 * 
 * problems: LogInfo doesn't stay on the same page (pagenum, sortby, etc.) after marking something as important - on index or searchIndex
    Have to click some buttons multiple times for them to work (submit on AdvancedSearch, etc.)
     */

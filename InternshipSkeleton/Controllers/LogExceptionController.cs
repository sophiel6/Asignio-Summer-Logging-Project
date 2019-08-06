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

        public ActionResult Index(int? id, string searchBy, string searchInput, string sortBy, string sortDir, Dictionary<string,string> searchDictionary)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string searchInfo = searchInput ?? "";
            string searchColumn = searchBy ?? "";
            string sortDirection = sortDir ?? "ASC";
            //Dictionary<string, string> searchDict;
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
            {
                searchDict = searchD;
            }
            else
            {
                searchDict = searchDictionary;
            }
            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, sortDirection, searchDict);
            return View(result);
        }
        /* 
         * reformat the Index method to take a dictionary of searchBy's and searchInput's 
         * IDictionary<string, string> searches = new Dictionary<string, string>();
         */
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
            {
                searchDict = searchD;
            }
            else
            {
                searchDict = searchDictionary;
            }
            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException("", "", pageSize,
                pageNum, sortColumn, sortDirection, searchDict); 

            return View(result);
        }
        /*
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
        }  */
        [HttpPost]
        public ActionResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogExceptionDataModel logToUpdate, 
            [System.Web.Http.FromBody]int pageNumber, [System.Web.Http.FromBody]string sortColumn, [System.Web.Http.FromBody]string sortDirection,
            [System.Web.Http.FromBody]Dictionary<string, string> searchDict)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logExceptionRepository.Update(logToUpdate, username);

            if (updatePerformed == 1) //update successfull
            {
                //string success = "Successfully marked as important";
                //return Json(new { IsCreated = true, Content = success });
                PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException("", "", 20, pageNumber, sortColumn, sortDirection, searchDict);
                return View("SearchIndex", result);
            }
            else //update failed 
            {
                //return Json(new { IsCreated = false, ErrorMessage = "Email entered by the user was not found in user database" });
                //return View("SearchIndex", modelToUpdate);
                PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException("", "", 20, pageNumber, sortColumn, sortDirection, searchDict);
                return View("SearchIndex", result);
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

        /*public ActionResult Search()
{
    return View();
}

public ActionResult SearchByMethodName()
{
    return View();
}

public ActionResult DisplayMethodNameSearchResult(int? id, string searchBy, string searchInput, string sortBy)
{
    int pageNum;
    pageNum = (id ?? 1);

    int pageSize = 20;
    string sortColumn = sortBy ?? "TimeStamp";
    string searchInfo = searchInput ?? "";
    string searchColumn = searchBy ?? "";
    PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(searchInfo, 
                                                                    searchColumn, pageSize, pageNum, sortColumn, "ASC");
    return View(result);
}

public ActionResult MarkAsImportant(CombinedLogExceptionDataModel logToUpdate)
{
    return View(logToUpdate);
} 

public ActionResult ImportantUpdated(CombinedLogExceptionDataModel logToUpdate)
{
    Guid UserID = m_logExceptionRepository.GetUserIDFromUsername(logToUpdate.Important); 

    m_logExceptionRepository.Update(logToUpdate, logToUpdate.Important);
    return View();
} */
    }
}

/*
 * To do - LogException:   
 * -maybe need to change more stuff to ajax calls? - ask about that 
 * -fix up the SearchIndex view 
 * -make the UpdateImportance take SearchDictionary as an input - so it's passed to 
 * 
 * To do - general
 * -make the active tab in the navbar appear selected
 * -change background of icons to be transparent (or change icon in general)
 * 
 * -combine PageLogException and NewPageLogException functions in repository 
 * -add stuff in Page repository function for stringing clauses together 
 * 
 *     
 */

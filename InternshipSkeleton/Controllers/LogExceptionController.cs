using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogException;
using AsignioInternship.Data.LogException;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogExceptionController : Controller
    {
        public LogExceptionController(ILogExceptionRepository logExceptionRepository)
        {
            m_logExceptionRepository = (logExceptionRepository != null) ? logExceptionRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string searchBy, string searchInput, string sortBy, string sortDir)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string searchInfo = searchInput ?? "";
            string searchColumn = searchBy ?? "";
            string sortDirection = sortDir ?? "ASC";
            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, sortDirection);
            return View(result);
        }
        /* 
         * reformat the Index method to take a dictionary of searchBy's and searchInput's 
         * IDictionary<string, string> searches = new Dictionary<string, string>();
         */
         public ActionResult IndexToo(int? id, Dictionary<string,string> searchDictionary, string sortBy, string sortDir)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string sortDirection = sortDir ?? "ASC";
            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.NewCombinedPageLogException(pageSize,
                pageNum, sortColumn, sortDirection, searchDictionary);
            //return Json(new { result = "Redirect", url = Url.Action("IndexToo", "LogException") });

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
 * -make querying by multiple categories possible - add Advanced Search page?
 *      link to Advanced Search, AdvancedSearch controller method, AdvancedSearch view
 *      AdvancedSearch view --> places to select options
 *      add new method to LogExceptionRepository to query sql table by these things and display? 
 *      
 * -add ability to only display logs that are marked as important (or is this necessary since I've made "sort descending" possible?)
 
 * -maybe need to change more stuff to ajax calls? - ask about that 
 * 
 * To do - general
 * -make the active tab in the navbar appear selected
 * -how should searching by "Important" work? - search by who marked as important or just by whether something is important
 * -change background of icons to be transparent (or change icon in general)
 */

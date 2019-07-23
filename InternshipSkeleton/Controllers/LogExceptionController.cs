using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogException;
using AsignioInternship.Data.LogException;
using System;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogExceptionController : Controller
    {
        public LogExceptionController(ILogExceptionRepository logExceptionRepository)
        {
            m_logExceptionRepository = (logExceptionRepository != null) ? logExceptionRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string searchBy, string searchInput, string sortBy)
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

        public ActionResult Search()
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
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogExceptionDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logExceptionRepository.Update(logToUpdate, username); 
            
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
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogExceptionDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logExceptionRepository.UndoUpdate(logToUpdate);

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

        private readonly ILogExceptionRepository m_logExceptionRepository;
    }
}

/*
 * To do: 
 * -change display of Important from email to an image 
 * -make querying by multiple categories possible? 
 * -implement changes for the other tables 
 */
using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogException;
using AsignioInternship.Data.LogException;
using System;
//using System.Web.Http;
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

        //Ajax call UpdateImportance method
        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogExceptionDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            //Guid UserID = m_logExceptionRepository.GetUserIDFromUsername(logToUpdate.Important);
            m_logExceptionRepository.Update(logToUpdate, username);
            
            //what does this function need to return in the JsonResult? 
            return Json(null);
        }   


        private readonly ILogExceptionRepository m_logExceptionRepository;

    }
}
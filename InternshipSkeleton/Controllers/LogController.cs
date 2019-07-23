using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLog;
using AsignioInternship.Data.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogController : Controller
    {
        public LogController(ILogRepository logRepository)
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
            PagedDataModelCollection<CombinedLogDataModel> result = m_logRepository.CombinedPageLog(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogDataModel> result = m_logRepository.GetAll();
            return View(result);
        }

        public ActionResult AddNew()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchByUserID()
        {
            return View();
        }

        public ActionResult DisplayUserIDResult(Guid UserID)
        {
            IEnumerable<LogDataModel> result = m_logRepository.GetAllFromUserID(UserID);
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogDataModel logToUpdate)
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
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogDataModel logToUpdate)
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

        private readonly ILogRepository m_logRepository;
    }
}
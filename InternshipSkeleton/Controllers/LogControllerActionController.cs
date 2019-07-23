using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogControllerAction;
using AsignioInternship.Data.LogControllerAction;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogControllerActionController : Controller
    {
        public LogControllerActionController(ILogControllerActionRepository logControllerActionRepository)
        {
            m_logControllerActionRepository = (logControllerActionRepository != null) ? logControllerActionRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string searchBy, string searchInput, string sortBy)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string searchInfo = searchInput ?? "";
            string searchColumn = searchBy ?? "";
            PagedDataModelCollection<CombinedLogControllerActionDataModel> result = m_logControllerActionRepository.CombinedPageLogControllerAction(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogControllerActionDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logControllerActionRepository.Update(logToUpdate, username);

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
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogControllerActionDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logControllerActionRepository.UndoUpdate(logToUpdate);

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

        private readonly ILogControllerActionRepository m_logControllerActionRepository;
    }
}
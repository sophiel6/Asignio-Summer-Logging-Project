using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogWebResponse;
using AsignioInternship.Data.LogWebResponse;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogWebResponseController : Controller
    {
        public LogWebResponseController(ILogWebResponseRepository logRepository)
        {
            m_logRepository = (logRepository != null) ? logRepository : throw new ArgumentNullException();
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
            PagedDataModelCollection<CombinedLogWebResponseDataModel> result = m_logRepository.CombinedPageLogWebResponse(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, sortDirection);
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogWebResponseDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logRepository.Update(logToUpdate, username);

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
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogWebResponseDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logRepository.UndoUpdate(logToUpdate);

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

        private readonly ILogWebResponseRepository m_logRepository;
    }
}
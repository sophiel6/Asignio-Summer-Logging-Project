using AsignioInternship.Data;
using AsignioInternship.Data.LogMySql;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogMySqlController : Controller
    {
        public LogMySqlController(ILogMySqlRepository logMySqlRepository)
        {
            m_logMySqlRepository = (logMySqlRepository != null) ? logMySqlRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string searchBy, string searchInput, string sortBy)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "DateTimeStamp";
            string searchInfo = searchInput ?? "";
            string searchColumn = searchBy ?? "";
            PagedDataModelCollection<LogMySqlDataModel> result = m_logMySqlRepository.PageLogMySql(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]LogMySqlDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logMySqlRepository.Update(logToUpdate, username);

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
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]LogMySqlDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logMySqlRepository.UndoUpdate(logToUpdate);

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

        private readonly ILogMySqlRepository m_logMySqlRepository;
    }
}
using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogInfo;
using AsignioInternship.Data.LogInfo;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogInfoController : Controller
    {
        public LogInfoController(ILogInfoRepository logInfoRepository)
        {
            m_logInfoRepository = (logInfoRepository != null) ? logInfoRepository : throw new ArgumentNullException();
        }

        public ActionResult Index(int? id, string searchBy, string searchInput, string sortBy)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string searchInfo = searchInput ?? "";
            string searchColumn = searchBy ?? "";
            PagedDataModelCollection<CombinedLogInfoDataModel> result = m_logInfoRepository.CombinedPageLogInfo(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        [HttpPost]
        public JsonResult UpdateImportance(string username, [System.Web.Http.FromBody]CombinedLogInfoDataModel logToUpdate)
        {
            logToUpdate.Important = username;
            int updatePerformed = m_logInfoRepository.Update(logToUpdate, username);

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
        public JsonResult MarkUnimportant([System.Web.Http.FromBody]CombinedLogInfoDataModel logToUpdate)
        {
            logToUpdate.Important = null;
            int updatePerformed = m_logInfoRepository.UndoUpdate(logToUpdate);

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

        private readonly ILogInfoRepository m_logInfoRepository;
    }
}
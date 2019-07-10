using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogException;
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
        /*public ActionResult Index()
        {
            IEnumerable<LogInfoDataModel> result = m_logInfoRepository.GetAll();
            return View(result);
        }*/
        public ActionResult Index(int? id, PagedDataModelCollection<CombinedLogInfoDataModel> model)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = (model.SortBy) ?? "TimeStamp";
            PagedDataModelCollection<CombinedLogInfoDataModel> result = m_logInfoRepository.CombinedPageLogException("",
                                                                    pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogInfoDataModel> result = m_logInfoRepository.GetAll();
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
            IEnumerable<LogInfoDataModel> result = m_logInfoRepository.GetAllFromUserID(UserID);
            return View(result);
        }
        private readonly ILogInfoRepository m_logInfoRepository;
    }
}
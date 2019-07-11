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

        public ActionResult Index(int? id, PagedDataModelCollection<LogDataModel> model)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = (model.SortBy) ?? "TimeStamp";
            string searchInfo = (model.SearchInput) ?? "";
            string searchColumn = (model.SearchBy) ?? "";
            PagedDataModelCollection<CombinedLogDataModel> result = m_logRepository.CombinedPageLog(searchInfo, searchColumn,
                                                                    pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }
        /*
        public ActionResult Index()
        {
            IEnumerable<LogDataModel> result = m_logRepository.GetAll();
            return View(result);
        }
        */

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

        private readonly ILogRepository m_logRepository;
    }
}
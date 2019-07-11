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
        /*public ActionResult Index()
        {
            IEnumerable<LogMySqlDataModel> result = m_logMySqlRepository.GetAll();
            return View(result);
        }*/

        public ActionResult Index(int? id, PagedDataModelCollection<LogMySqlDataModel> model)
        {
            int pageNum = (id ?? 1);
            int pageSize = 68;
            string sortColumn = (model.SortBy) ?? "DateTimeStamp";
            string searchInfo = (model.SearchInput) ?? "";
            string searchColumn = (model.SearchBy) ?? "";
            PagedDataModelCollection<LogMySqlDataModel> result = m_logMySqlRepository.PageLogMySql(searchInfo,
                                                                    pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogMySqlDataModel> result = m_logMySqlRepository.GetAll();
            return View(result);
        }

        public ActionResult AddNew()
        {
            return View();
        }

        private readonly ILogMySqlRepository m_logMySqlRepository;
    }
}
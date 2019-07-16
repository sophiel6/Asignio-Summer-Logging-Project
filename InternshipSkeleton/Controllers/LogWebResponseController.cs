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

        /* public ActionResult Index(int? id, PagedDataModelCollection<LogWebResponseDataModel> model)
         {
             int pageNum = (id ?? 1);
             int pageSize = 20;
             string sortColumn = (model.SortBy) ?? "TimeStamp";
             string searchInfo = (model.SearchInput) ?? "";
             string searchColumn = (model.SearchBy) ?? "";
             PagedDataModelCollection<CombinedLogWebResponseDataModel> result = m_logRepository.CombinedPageLogWebResponse(searchInfo, 
                                                                                 searchColumn, pageSize, pageNum, sortColumn, "ASC");
             return View(result);
         } */
        public ActionResult Index(int? id, string searchBy, string searchInput, string sortBy)
        {
            int pageNum;
            pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string searchInfo = searchInput ?? "";
            string searchColumn = searchBy ?? "";
            PagedDataModelCollection<CombinedLogWebResponseDataModel> result = m_logRepository.CombinedPageLogWebResponse(searchInfo,
                                                                            searchColumn, pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogWebResponseDataModel> result = m_logRepository.GetAll();
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
            IEnumerable<LogWebResponseDataModel> result = m_logRepository.GetAllFromUserID(UserID);
            return View(result);
        }
        private readonly ILogWebResponseRepository m_logRepository;
    }
}
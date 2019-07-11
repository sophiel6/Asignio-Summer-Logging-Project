using AsignioInternship.Data;
using AsignioInternship.Data.LogWebRequest;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogWebRequestController : Controller
    {
        public LogWebRequestController(ILogWebRequestRepository logWebRequestRepository)
        {
            m_logWebRequestRepository = (logWebRequestRepository != null) ? logWebRequestRepository : throw new ArgumentNullException();
        }
        /*public ActionResult Index()
        {
            IEnumerable<LogWebRequestDataModel> result = m_logWebRequestRepository.GetAll();
            return View(result);
            //return View();
        }*/

        public ActionResult Index(int? id, PagedDataModelCollection<LogWebRequestDataModel> model)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = (model.SortBy) ?? "TimeStamp";
            string searchInfo = (model.SearchInput) ?? "";
            string searchColumn = (model.SearchBy) ?? "";
            PagedDataModelCollection<LogWebRequestDataModel> result = m_logWebRequestRepository.PageLogWebRequest(searchInfo, 
                                                                    pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogWebRequestDataModel> result = m_logWebRequestRepository.GetAll();
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
            IEnumerable<LogWebRequestDataModel> result = m_logWebRequestRepository.GetAllFromUserID(UserID);
            return View(result);
        }
        private readonly ILogWebRequestRepository m_logWebRequestRepository;
    }
}
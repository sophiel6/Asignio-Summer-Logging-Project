using AsignioInternship.Data;
using AsignioInternship.Data.LogException;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogExceptionController : Controller
    {
        public LogExceptionController(ILogExceptionRepository logExceptionRepository)
        {
            m_logExceptionRepository = (logExceptionRepository != null) ? logExceptionRepository : throw new ArgumentNullException();
        }
        public ActionResult Index(int? id, PagedDataModelCollection<LogExceptionDataModel> model)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = (model.SortBy) ?? "TimeStamp";
            PagedDataModelCollection<LogExceptionDataModel> result = m_logExceptionRepository.PageLogException("", 
                                                                    pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchByUserID()
        {
            return View();
        }

        public ActionResult DisplayUserIDResult(Guid UserID, int? id)
        {
            
            IEnumerable<LogExceptionDataModel> result = m_logExceptionRepository.GetAllFromUserID(UserID);
            return View(result);
            /*
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string userIDstring = UserID.ToString("D");
            PagedDataModelCollection<LogExceptionDataModel> result = m_logExceptionRepository.PageLogException(userIDstring,
                                                                    pageSize, pageNum, "TimeStamp", "ASC");
            return View(result);
            */
        }


        private readonly ILogExceptionRepository m_logExceptionRepository;
    }
}
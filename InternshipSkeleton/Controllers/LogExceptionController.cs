using AsignioInternship.Data;
using AsignioInternship.Data.CombinedLogException;
using AsignioInternship.Data.LogException;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogExceptionController : Controller
    {
        public LogExceptionController(ILogExceptionRepository logExceptionRepository)
        {
            m_logExceptionRepository = (logExceptionRepository != null) ? logExceptionRepository : throw new ArgumentNullException();
        }
        
        public ActionResult Index(int? id, string sortBy)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = (sortBy) ?? "TimeStamp";
            string searchInfo = "";
            string searchColumn = "";
            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(searchInfo, searchColumn,
                                                                    pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }
        
        /*
        public ActionResult Index(int? id)
        {
            IEnumerable<CombinedLogExceptionDataModel> result = m_logExceptionRepository.ExampleQuery();
            return View(result);
        } */

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchByMethodName()
        {
            return View();
        }

        public ActionResult DisplayMethodNameSearchResult(int? id, string searchBy, string searchInput, string sortBy)
        {
            int pageNum;
            pageNum = (id ?? 1);

            int pageSize = 20;
            string sortColumn = sortBy ?? "TimeStamp";
            string searchInfo = searchInput ?? "";
            string searchColumn = searchBy ?? "";
            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(searchInfo, 
                                                                            searchColumn, pageSize, pageNum, sortColumn, "ASC");
            return View(result);
        }
        private readonly ILogExceptionRepository m_logExceptionRepository;
    }
}
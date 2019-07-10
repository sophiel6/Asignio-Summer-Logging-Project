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
        
        public ActionResult Index(int? id, PagedDataModelCollection<LogExceptionDataModel> model)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = (model.SortBy) ?? "TimeStamp";
            string searchInfo = (model.SearchInput) ?? "";
            string searchColumn = (model.SearchBy) ?? "";
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

        public ActionResult DisplayMethodNameSearchResult(int? id, PagedDataModelCollection<LogExceptionDataModel> model)
        {
            int pageNum = (id ?? 1);
            int pageSize = 20;
            string sortColumn = (model.SortBy) ?? "TimeStamp";
            string searchInfo = (model.SearchInput) ?? "";
            string searchColumn = (model.SearchBy) ?? "";
            PagedDataModelCollection<CombinedLogExceptionDataModel> result = m_logExceptionRepository.CombinedPageLogException(searchInfo, 
                                                                            searchColumn, pageSize, pageNum, sortColumn, "ASC");
            return View(result);

        }


        private readonly ILogExceptionRepository m_logExceptionRepository;
    }
}
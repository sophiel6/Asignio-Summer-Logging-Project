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
        public ActionResult Index()
        {
           //IEnumerable<LogExceptionDataModel> result = m_logExceptionRepository.GetAll();
           //return View(result); 

            
            //int pageNum = (int)id;
            int pageNum = 1;
      
            int pageSize = 20;
            PagedDataModelCollection<LogExceptionDataModel> result = m_logExceptionRepository.PageLogException("", 
                                                                    pageSize, pageNum, "TimeStamp", "ASC");
            return View(result.Items);
            
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogExceptionDataModel> result = m_logExceptionRepository.GetAll();
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
            IEnumerable<LogExceptionDataModel> result = m_logExceptionRepository.GetAllFromUserID(UserID);
            return View(result);
        }
        private readonly ILogExceptionRepository m_logExceptionRepository;
    }
}
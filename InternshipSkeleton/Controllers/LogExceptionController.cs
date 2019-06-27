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
            IEnumerable<LogExceptionDataModel> result = m_logExceptionRepository.GetAll();
            return View(result);
            //return View();
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
        /*
        public ActionResult Update(Guid UserID)
        {
            LogExceptionDataModel result = m_logExceptionRepository.GetFromID(UserID);
            return View(result);
        }

        public ActionResult SubmitNewExample(ExampleDataModel model)
        {
            m_ExampleRepository.Insert(model);
            return View();
        }
        */
        private readonly ILogExceptionRepository m_logExceptionRepository;
    }
}
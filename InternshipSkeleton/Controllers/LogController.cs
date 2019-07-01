using AsignioInternship.Data.Log;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogController : Controller
    {
        public LogController(ILogRepository logRepository)
        {
            m_logRepository = (logRepository != null) ? logRepository : throw new ArgumentNullException();
        }
        public ActionResult Index()
        {
            IEnumerable<LogDataModel> result = m_logRepository.GetAll();
            return View(result);
            //return View();
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogDataModel> result = m_logRepository.GetAll();
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

            //added by Sophie
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchByUserID()
        {
            //LogDataModel result = m_logRepository.GetFromUserID(UserID);
            return View();
        }

        public ActionResult DisplayUserIDResult(Guid UserID)
        {
            LogDataModel result = m_logRepository.GetFromUserID(UserID);
            return View(result);
        }

        private readonly ILogRepository m_logRepository;
    }
}
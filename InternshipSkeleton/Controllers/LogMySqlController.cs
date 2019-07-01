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
        public ActionResult Index()
        {
            IEnumerable<LogMySqlDataModel> result = m_logMySqlRepository.GetAll();
            return View(result);
            //return View();
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
        private readonly ILogMySqlRepository m_logMySqlRepository;
    }
}
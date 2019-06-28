using AsignioInternship.Data.LogControllerAction;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogControllerActionController : Controller
    {
        public LogControllerActionController(ILogControllerActionRepository logControllerActionRepository)
        {
            m_logControllerActionRepository = (logControllerActionRepository != null) ? logControllerActionRepository : throw new ArgumentNullException();
        }
        public ActionResult Index()
        {
            IEnumerable<LogControllerActionDataModel> result = m_logControllerActionRepository.GetAll();
            return View(result);
            //return View();
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogControllerActionDataModel> result = m_logControllerActionRepository.GetAll();
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
        private readonly ILogControllerActionRepository m_logControllerActionRepository;
    }
}
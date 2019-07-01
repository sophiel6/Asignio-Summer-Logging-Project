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
            IEnumerable<LogControllerActionDataModel> result = m_logControllerActionRepository.GetAllFromUserID(UserID);
            return View(result);
        }

        private readonly ILogControllerActionRepository m_logControllerActionRepository;
    }
}
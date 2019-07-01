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
        public ActionResult Index()
        {
            IEnumerable<LogWebRequestDataModel> result = m_logWebRequestRepository.GetAll();
            return View(result);
            //return View();
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
        private readonly ILogWebRequestRepository m_logWebRequestRepository;
    }
}
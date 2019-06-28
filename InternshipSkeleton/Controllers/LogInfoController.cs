using AsignioInternship.Data.LogInfo;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class LogInfoController : Controller
    {
        public LogInfoController(ILogInfoRepository logInfoRepository)
        {
            m_logInfoRepository = (logInfoRepository != null) ? logInfoRepository : throw new ArgumentNullException();
        }
        public ActionResult Index()
        {
            IEnumerable<LogInfoDataModel> result = m_logInfoRepository.GetAll();
            return View(result);
            //return View();
        }

        public ActionResult ViewAll()
        {
            IEnumerable<LogInfoDataModel> result = m_logInfoRepository.GetAll();
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
        private readonly ILogInfoRepository m_logInfoRepository;
    }
}
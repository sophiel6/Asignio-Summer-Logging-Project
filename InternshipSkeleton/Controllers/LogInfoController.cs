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
            IEnumerable<LogInfoDataModel> result = m_logInfoRepository.GetAllFromUserID(UserID);
            return View(result);
        }
        private readonly ILogInfoRepository m_logInfoRepository;
    }
}
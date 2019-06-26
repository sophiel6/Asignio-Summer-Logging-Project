using AsignioInternship.Data.Example;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AsignioInternship.Controllers
{
    public class ExampleController : Controller
    {
        public ExampleController(IExampleRepository exampleRepository)
		{
			m_ExampleRepository = (exampleRepository != null) ? exampleRepository : throw new ArgumentNullException();
		}
        public ActionResult Index()
        {
			return View();
        }

		public ActionResult ViewAll()
		{
			IEnumerable<ExampleDataModel> result = m_ExampleRepository.GetAll();
			return View(result);
		}

		public ActionResult AddNew()
		{
			return View();
		}

		public ActionResult Update(Guid UserID)
		{
			ExampleDataModel result = m_ExampleRepository.GetFromID(UserID);
			return View(result);
		}

		public ActionResult SubmitNewExample(ExampleDataModel model)
		{
			m_ExampleRepository.Insert(model);
			return View();
		}

		private readonly IExampleRepository m_ExampleRepository;
    }
}
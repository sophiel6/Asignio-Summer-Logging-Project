using System;
using System.Collections.Generic;

namespace AsignioInternship.Data.Example
{
	public interface IExampleRepository
	{
		ExampleDataModel GetFromID(Guid ExampleID);
		ExampleDataModel Insert(ExampleDataModel dataModel);
		IEnumerable<ExampleDataModel> GetAll();
	}
}

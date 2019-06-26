using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.Example
{
	public class ExampleDataModel
	{
		public Guid ExampleID { get; set; }
		public string Name { get; set; }
		public int IntValue { get; set; }
		public string StringValue { get; set; }
		public bool BoolValue { get; set; }
		public double DoubleValue { get; set; }
		public DateTime DateAdded { get; set; }
	}
}

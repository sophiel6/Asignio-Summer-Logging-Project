using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.Example
{

	[PetaPoco.TableName("example")]
	[PetaPoco.PrimaryKey("ExampleID", autoIncrement = false)]
	internal class ExamplePoco
	{

		#region SQL

		internal static readonly string BaseSQL  = @"
            SELECT
           * from example";
		internal static readonly string SelectByIDSQL = BaseSQL + " where ExampleID=@0;";
		internal static readonly string SelectAll = BaseSQL + " ORDER BY DateAdded desc;";
		#endregion

		public byte[] ExampleID { get; set; }
		public string Name { get; set; }
		public int IntValue { get; set; }
		public string StringValue { get; set; }
		public bool BoolValue { get; set; }
		public double DoubleValue { get; set; }
		public DateTime DateAdded { get; set; }
	}
}

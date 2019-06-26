using System;
using PetaPoco;

namespace AsignioInternship.Data
{
	public class AsignioDatabase : PetaPoco.Database
	{
		public AsignioDatabase(string connectionStringName)
			: base(connectionStringName)
		{
		}

		public override bool OnException(Exception x)
		{
			// TODO: Add logging on this exception...
			return base.OnException(x);
		}
	}
}

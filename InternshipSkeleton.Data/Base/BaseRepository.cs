using System;

namespace IntershipSkeleton.Demos.Data.Repositories
{
	public class BaseRepository
	{

		#region Properties

		protected string ConnectionStringName;
		private const string CONNECTIONSTRINGNAME = "DefaultConnection";		
		
		#endregion

		#region Constructors

		internal BaseRepository(Type type)
			: this(type, CONNECTIONSTRINGNAME)
		{
		}

		internal BaseRepository(Type type, string connectionStringName)
		{
			this.ConnectionStringName = connectionStringName;
		}

		#endregion

	}
}

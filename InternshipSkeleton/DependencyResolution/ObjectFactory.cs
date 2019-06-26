
namespace AsignioInternship.DependencyResolution
{
	using StructureMap;

	public class ObjectFactory
	{
		public static IContainer Container { get; private set; }

		public static ObjectFactory Set(IContainer container)
		{
			if (instance == null)
			{
				instance = new ObjectFactory();
				Container = container;
				container.AssertConfigurationIsValid();
			}

			return instance;
		}

		private static ObjectFactory instance;

		private ObjectFactory()
		{
		}
	}
}
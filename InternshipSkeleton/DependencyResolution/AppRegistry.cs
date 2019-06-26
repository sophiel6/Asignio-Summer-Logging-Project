using AsignioInternship.Data.Example;


namespace AsignioInternship.DependencyResolution
{
    using StructureMap;

	public class AppRegistry : Registry
	{
		public AppRegistry()
			: base()
		{			

			Scan(
				scan => {
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
				});
			For<IExampleRepository>().Singleton().Use<ExampleRepository>();
        }
    }
}
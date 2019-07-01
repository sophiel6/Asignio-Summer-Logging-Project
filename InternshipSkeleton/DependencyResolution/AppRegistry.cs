//using AsignioInternship.Data.Example;

namespace AsignioInternship.DependencyResolution
{
    using AsignioInternship.Data.Example;
    using AsignioInternship.Data.Log;
    using AsignioInternship.Data.LogControllerAction;
    using AsignioInternship.Data.LogException;
    using AsignioInternship.Data.LogInfo;
    using AsignioInternship.Data.LogMySql;
    using AsignioInternship.Data.LogWebRequest;
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

            For<ILogExceptionRepository>().Singleton().Use<LogExceptionRepository>();

            For<ILogRepository>().Singleton().Use<LogRepository>();

            For<ILogControllerActionRepository>().Singleton().Use<LogControllerActionRepository>();

            For<ILogInfoRepository>().Singleton().Use<LogInfoRepository>();

            For<ILogMySqlRepository>().Singleton().Use<LogMySqlRepository>();

            For<ILogWebRequestRepository>().Singleton().Use<LogWebRequestRepository>();
        }
    }
}
using Microsoft.AspNet.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Extensions.PlatformAbstractions;

namespace <%= name %>
{
    public class Program
    {
        private readonly ILibraryManager runtimeServices;
        
        public Program(ILibraryManager runtimeServices)
        {
            this.runtimeServices = runtimeServices;
        }
        
        public void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(x => runtimeServices);
            var startup = new Startup(null);
            startup.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var controllerProvider = serviceProvider.GetService<IControllerTypeProvider>();
            var converter = new Converter(new WaAdapter());
            converter.Write(controllerProvider.ControllerTypes.Select(x => x.AsType()),
                "src/services/services.ts",
                "bower_components/folke-ko-service-helpers/folke-ko-service-helpers",
                "bower_components/folke-ko-validation/folke-ko-validation");
        }
    }
}

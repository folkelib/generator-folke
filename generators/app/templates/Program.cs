using Folke.CsTsService;
using <%= name %>.Controllers;

namespace <%= name %>
{
    public class Program
    {
        static void Main(string[] args)
        {
            var converter = new Converter(new WaAdapter());
            converter.Write(new[] { typeof(AccountController).Assembly },
                "src/services/services.ts",
                "bower_components/folke-ko-service-helpers/folke-ko-service-helpers",
                "bower_components/folke-ko-validation/folke-ko-validation");
        }
    }
}


namespace Application.Util
{
    public class Properties{
         // Set up configuration builder with the path to the Properties folder
        public IConfigurationRoot GetProperties(){
        return new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Base path of the application
        .AddJsonFile("Properties/properties.json", optional: false, reloadOnChange: true) // Path relative to the base path
        .Build();
        }
    }
}


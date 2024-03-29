using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        Host.CreateDefaultBuilder()
            .ConfigureServices(ConfigureServices)
            .ConfigureServices(services => services.AddSingleton<Executor>())
            .Build()
            .Services
            .GetService<Executor>()
            .Execute();
    }

    private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
    {
        services.AddSingleton<ITest, Test>();
    }
}
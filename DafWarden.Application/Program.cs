using DafWarden.Application;
using DafWarden.Domain;
using DafWarden.Domain.Adapters;
using DafWarden.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
    .ConfigureServices(ConfigureServices)
    .ConfigureServices(services => services.AddSingleton<Executor>())
    .Build().Services
    .GetService<Executor>()
    .Execute();

static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
{
    services.AddSingleton<IPassphraseGenerator, PassphraseGenerator>();
    services.AddSingleton<IPassphraseFragementRepository, PassphraseFragmentRepository>();
}

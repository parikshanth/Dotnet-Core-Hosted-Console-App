using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;

namespace HostedConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "{Timestamp:G} [{Level:u3}] [{SourceContext}] {Message} {NewLine:1}{Exception:1}")
                .CreateLogger();

            await new HostBuilder().ConfigureServices((hostContext, service) =>
            {
                service.AddScoped<IHostedService, TestService>();
            }).UseSerilog().RunConsoleAsync();



        }
    }
}

using Microsoft.AspNetCore;

namespace Mds.TddExample.Api;
public class Program
{
    public static async Task Main(string[] args)
    {
        var host = BuildWebHost(args);

        host.Run();
    }

    public static IWebHost BuildWebHost(string[] args)
    {
        return WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}

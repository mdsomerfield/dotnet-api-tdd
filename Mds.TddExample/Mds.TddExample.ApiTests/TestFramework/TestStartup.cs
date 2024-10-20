using Autofac;
using Autofac.Extensions.DependencyInjection;
using Mds.TddExample.Api;

namespace Mds.TddExample.ApiTests.TestFramework;

public class TestStartup
{
    public IConfiguration Configuration { get; }

    public IContainer ApplicationContainer { get; private set; }

    public TestStartup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
                    //.AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.Test.json", true)
                    .AddEnvironmentVariables()
           .Build();

        Configuration = configuration;
    }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        var builder = Startup.BuildContainer(services, Configuration);

        ApplicationContainer = builder.Build();

        return new AutofacServiceProvider(ApplicationContainer);
    }

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        Startup.ConfigureApp(app, env);
    }

}

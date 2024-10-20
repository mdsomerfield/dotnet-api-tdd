using System.Text.Json.Serialization;
using Autofac;
using Autofac.Extensions.DependencyInjection;

using Mds.TddExample.Db;
using Mds.TddExample.Db.Entities;
using Mds.TddExample.Domain.Domains.Helicopters.Commands;
using Microsoft.EntityFrameworkCore;

namespace Mds.TddExample.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public IContainer ApplicationContainer { get; private set; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                    .AddEnvironmentVariables()
           .Build();

        Configuration = configuration;
    }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        var builder = BuildContainer(services, Configuration);

        ApplicationContainer = builder.Build();

        return new AutofacServiceProvider(ApplicationContainer);
    }

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ConfigureApp(app, env);
    }

    // Setup factored into static methods so that it can be shared easily with the TestStartup class.
    #region static setup

    public static ContainerBuilder BuildContainer(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddAntiforgery();

        services.AddAuthorization(options => { });

        var connStr = configuration.GetConnectionString("ApplicationConnectionString");
        services.AddDbContext<ApplicationDbContext>(
            optionsAction: options =>
                options
                    .UseNpgsql(connStr, x => x.MigrationsHistoryTable("__EFMigrationsHistory", "dbo"))
        );

        var builder = new ContainerBuilder();

        builder.Populate(services);

        builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(typeof(CreateHelicopterCommand).Assembly).AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(typeof(Helicopter).Assembly).AsImplementedInterfaces();
        builder.RegisterType<ApplicationDbContext>();

        return builder;
    }

    public static void ConfigureApp(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    #endregion

}

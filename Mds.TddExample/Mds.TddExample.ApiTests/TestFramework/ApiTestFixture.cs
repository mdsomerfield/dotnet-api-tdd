using Mds.TddExample.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Mds.TddExample.ApiTests.TestFramework;

[CollectionDefinition("ApiTest")]
public class GlobalCollectionFixture : ICollectionFixture<ApiTestFixture> { }
public class ApiTestFixture
{
    private static TestApplicationFactory Factory { get; } = new();

    public ApiTestFixture()
    {
        using var scope = Factory.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();
    }

    public JsonClient CreateClient()
    {
        return new JsonClient(Factory.CreateClient());
    }
}
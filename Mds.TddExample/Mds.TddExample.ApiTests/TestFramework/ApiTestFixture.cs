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
    }

    public JsonClient CreateClient()
    {
        return new JsonClient(Factory.CreateClient());
    }
}
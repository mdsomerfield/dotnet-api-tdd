using Mds.TddExample.Api.HelloWorld;
using Mds.TddExample.ApiTests.TestFramework;
using Xunit;

namespace Mds.TddExample.ApiTests.EndpointTests;

[Collection("ApiTest")]
public class HelloWorldTests
{
    private readonly ApiTestFixture _fixture;

    public HelloWorldTests(ApiTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task HelloWorld_ReturnsHelloWorld()
    {
        // Arrange
        var client = _fixture.CreateClient();

        // Act
        var response = await client.GetAsync<HelloWorldResponse>("/hello-world");

        // Assert
        Assert.NotNull(response.Body);
        Assert.Equal("Hello, World!", response.Body.Message);
    }
}

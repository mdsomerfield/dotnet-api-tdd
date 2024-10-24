using System.Net;
using FluentAssertions;
using Mds.TddExample.ApiTests.Helpers.Helicopters;
using Mds.TddExample.ApiTests.TestFramework;
using Xunit;

namespace Mds.TddExample.ApiTests.WorkflowTests
{
    [Collection("ApiTest")]
    public class HelicopterCrudTests : DefaultTestFixture
    {
        public HelicopterCrudTests(ApiTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Can_CRUD_Helicopter()
        {
            var helicoptersApi = new HelicoptersApi(Fixture);

            // 1. Get all helicopters (expect 0)
            var helicopters1 = await helicoptersApi.GetAllHelicopters();
            helicopters1.Should().BeEmpty();

            // 2. Create a new helicopter
            var helicopterBuilder = new HelicopterBuilder();
            var newHelicopter = await helicoptersApi.CreateHelicopter(helicopterBuilder.Build());
            helicopterBuilder.ShouldMatch(newHelicopter);

            // 3. Get all helicopters (expect 1)
            var helicopters2 = await helicoptersApi.GetAllHelicopters();
            helicopters2.Should().HaveCount(1);

            // 4. Get the new helicopter
            var createdHelicopter = await helicoptersApi.GetHelicopter(newHelicopter.Id);
            helicopterBuilder.ShouldMatch(createdHelicopter);

            // 5. Update the new helicopter
            var updatedHelicopterBuilder = helicopterBuilder.Clone().WithName("Name");
            var updatedHelicopterDto = updatedHelicopterBuilder.Build();
            var updatedHelicopter1 = await helicoptersApi.UpdateHelicopter(newHelicopter.Id, updatedHelicopterDto);
            updatedHelicopterBuilder.ShouldMatch(updatedHelicopter1);

            // 6. Get the new helicopter (expect updated)
            var updatedHelicopter2 = await helicoptersApi.GetHelicopter(newHelicopter.Id);
            updatedHelicopterBuilder.ShouldMatch(updatedHelicopter2);

            // 7. Delete the new helicopter
            await helicoptersApi.DeleteHelicopter(newHelicopter.Id);

            // 8. Get the helicopter (expect 404)
            try
            {
                await helicoptersApi.GetHelicopter(newHelicopter.Id);
            }
            catch (HttpRequestException ex)
            {
                ex.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            // 9. Get all helicopters (expect 0)
            var helicopters3 = await helicoptersApi.GetAllHelicopters();
            helicopters3.Should().HaveCount(0);
        }
    }
}

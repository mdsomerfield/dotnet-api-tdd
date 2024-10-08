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
            newHelicopter.Name.Should().Be(helicopterBuilder.Instance.Name);

            // 3. Get all helicopters (expect 1)
            var helicopters2 = await helicoptersApi.GetAllHelicopters();
            helicopters2.Should().HaveCount(1);

            // 4. Get the new helicopter
            var createdHelicopter = await helicoptersApi.GetHelicopter(newHelicopter.Id);
            createdHelicopter.Name.Should().Be(newHelicopter.Name);

            // 5. Update the new helicopter
            var updatedHelicopterDto = helicopterBuilder.Clone().WithName().Build();
            var updatedHelicopter1 = await helicoptersApi.UpdateHelicopter(newHelicopter.Id, updatedHelicopterDto);
            updatedHelicopter1.Name.Should().Be(updatedHelicopterDto.Name);

            // 6. Get the new helicopter (expect updated)
            var updatedHelicopter2 = await helicoptersApi.GetHelicopter(newHelicopter.Id);
            updatedHelicopter2.Name.Should().Be(updatedHelicopterDto.Name);

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

using System.Net;
using FluentAssertions;
using Mds.TddExample.Api.Domains.Schedules;
using Mds.TddExample.ApiTests.Helpers.Helicopters;
using Mds.TddExample.ApiTests.Helpers.Schedules;
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

            // 1. Create a new helicopter
            var helicopterBuilder = new HelicopterBuilder();
            var newHelicopter = await helicoptersApi.CreateHelicopter(helicopterBuilder.Build());
            helicopterBuilder.ShouldMatch(newHelicopter);

            // 2. Get all helicopters (expect 1)
            var helicopters2 = await helicoptersApi.GetAllHelicopters();
            helicopters2.Should().Contain(c => c.Id == newHelicopter.Id);

            // 3. Get the new helicopter
            var createdHelicopter = await helicoptersApi.GetHelicopter(newHelicopter.Id);
            helicopterBuilder.ShouldMatch(createdHelicopter);

            // 4. Update the new helicopter
            var updatedHelicopterBuilder = helicopterBuilder.Clone().WithName("Name");
            var updatedHelicopterDto = updatedHelicopterBuilder.Build();
            var updatedHelicopter1 = await helicoptersApi.UpdateHelicopter(newHelicopter.Id, updatedHelicopterDto);
            updatedHelicopterBuilder.ShouldMatch(updatedHelicopter1);

            // 5. Get the new helicopter (expect updated)
            var updatedHelicopter2 = await helicoptersApi.GetHelicopter(newHelicopter.Id);
            updatedHelicopterBuilder.ShouldMatch(updatedHelicopter2);

            // 6. Delete the new helicopter
            await helicoptersApi.DeleteHelicopter(newHelicopter.Id);

            // 7. Get the helicopter (expect 404)
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

        [Fact]
        public async Task Can_CRUD_HelicopterSchedule()
        {
            // 1. Create a new helicopter
            var helicoptersApi = new HelicoptersApi(Fixture);
            var helicopterBuilder = new HelicopterBuilder();
            var newHelicopter = await helicoptersApi.CreateHelicopter(helicopterBuilder.Build());

            // 2. Set helicopter schedule
            var scheduler = new SchedulesApi(Fixture);
            var scheduleBuilder = new ScheduleBuilder()
                .WithDailyHours(DayOfWeek.Monday, new TimeSpan(9, 0, 0), new TimeSpan(5, 0, 0))
                .WithDailyHours(DayOfWeek.Tuesday, new TimeSpan(9, 30, 0), new TimeSpan(5, 0, 0))
                .WithDailyHours(DayOfWeek.Wednesday, new TimeSpan(9, 30, 0), new TimeSpan(6, 15, 0))
                .WithHelicopter(newHelicopter.Id); 
            var schedule = await scheduler.CreateSchedule(scheduleBuilder.Build());
            scheduleBuilder.ShouldMatch(schedule);

            // 3. Get the helicopter schedule
            var schedule2 = await scheduler.GetSchedule(schedule.Id);
            scheduleBuilder.ShouldMatch(schedule2);
        }
    }
}

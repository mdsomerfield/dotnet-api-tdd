using Mds.TddExample.Api.Domains.Schedules;
using Mds.TddExample.ApiTests.TestFramework;

namespace Mds.TddExample.ApiTests.Helpers.Schedules;

public class SchedulesApi
{
    private readonly JsonClient _jsonClient;

    public SchedulesApi(ApiTestFixture fixture)
    {
        _jsonClient = fixture.CreateClient();
    }

    public async Task<IList<ScheduleDto>> GetAllSchedules()
    {
        var response = await _jsonClient.GetAsync<IList<ScheduleDto>>("schedules");
        return response.Body;
    }

    public async Task<ScheduleDto> CreateSchedule(ScheduleDto createModel)
    {
        var response = await _jsonClient.PostAsync<ScheduleDto, ScheduleDto>("schedules", createModel);
        return response.Body;
    }

    public async Task<ScheduleDto> GetSchedule(int resourceId)
    {
        var response = await _jsonClient.GetAsync<ScheduleDto>($"schedules/{resourceId}");
        return response.Body;
    }

    public async Task<ScheduleDto> UpdateSchedule(int resourceId, ScheduleDto updateModel)
    {
        var response = await _jsonClient.PutAsync<ScheduleDto, ScheduleDto>($"schedules/{resourceId}", updateModel);
        return response.Body;
    }

    public async Task DeleteSchedule(int resourceId)
    {
        await _jsonClient.DeleteAsync($"schedules/{resourceId}");
    }
}
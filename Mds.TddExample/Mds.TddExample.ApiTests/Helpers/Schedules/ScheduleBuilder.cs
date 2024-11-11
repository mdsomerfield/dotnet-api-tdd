using FluentAssertions;
using Mds.TddExample.Api.Domains.Schedules;

namespace Mds.TddExample.ApiTests.Helpers.Schedules;

public class ScheduleBuilder
{
    public ScheduleDto Instance { get; }

    public ScheduleBuilder()
    {
        Instance = new ScheduleDto();
    }

    public ScheduleBuilder WithDailyHours(DayOfWeek dayOfWeek, TimeSpan start, TimeSpan end)
    {
        Instance.Slots.Add(new ScheduleSlotDto { DayOfWeek = dayOfWeek, Start = start, End = end });
        return this;
    }

    public ScheduleBuilder WithHelicopter(int newHelicopterId)
    {
        Instance.HelicopterId = newHelicopterId;
        return this;
    }

    public ScheduleDto Build()
    {
        return Instance;
    }

    public void ShouldMatch(ScheduleDto schedule)
    {
        schedule.HelicopterId.Should().Be(Instance.HelicopterId);
        schedule.Slots.Should().BeEquivalentTo(Instance.Slots);
    }
}
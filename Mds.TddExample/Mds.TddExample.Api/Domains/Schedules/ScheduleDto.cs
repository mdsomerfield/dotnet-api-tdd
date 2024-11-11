namespace Mds.TddExample.Api.Domains.Schedules
{
    public record CreateScheduleDto
    {
        public int HelicopterId { get; set; }
        public IList<ScheduleSlotDto> Slots { get; set; } = new List<ScheduleSlotDto>();
    }

    public record ScheduleDto : CreateScheduleDto
    {
        public int Id { get; set; }
    }

    public record ScheduleSlotDto
    {
        public DateOnly? Date { get; init; }
        public int? DayOfMonth { get; init; }
        public DayOfWeek? DayOfWeek { get; init; }
        public TimeSpan Start { get; init; }
        public TimeSpan End { get; set; }
    }
}

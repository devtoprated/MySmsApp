using System;
using System.Collections.Generic;

namespace DataService.Entities;

public partial class UserDataTable
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Account { get; set; }

    public string? House { get; set; }

    public string? Address { get; set; }

    public DateTime? ScheduleDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public TimeSpan? ActualStartTime { get; set; }

    public TimeSpan? ActualEndTime { get; set; }
}

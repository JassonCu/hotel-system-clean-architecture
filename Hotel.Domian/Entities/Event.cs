using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }
}

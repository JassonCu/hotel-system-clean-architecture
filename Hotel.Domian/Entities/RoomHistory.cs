using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class RoomHistory
{
    public int HistoryId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly ChangeDate { get; set; }

    public int? ChangedBy { get; set; }

    public string? Description { get; set; }

    public virtual SystemUser? ChangedByNavigation { get; set; }

    public virtual Room? Room { get; set; }
}

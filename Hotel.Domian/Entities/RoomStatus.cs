using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class RoomStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}

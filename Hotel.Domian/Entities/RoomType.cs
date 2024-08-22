using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<SeasonalRate> SeasonalRates { get; set; } = new List<SeasonalRate>();
}

using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class SeasonalRate
{
    public int RateId { get; set; }

    public int? RoomTypeId { get; set; }

    public string SeasonName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal Rate { get; set; }

    public virtual RoomType? RoomType { get; set; }
}

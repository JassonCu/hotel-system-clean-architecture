using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? GuestId { get; set; }

    public int? ReservationId { get; set; }

    public DateOnly ReviewDate { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Reservation? Reservation { get; set; }
}

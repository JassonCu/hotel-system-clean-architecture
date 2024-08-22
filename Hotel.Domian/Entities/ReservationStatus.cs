using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class ReservationStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

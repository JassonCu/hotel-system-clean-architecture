using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class RoomServiceOrder
{
    public int OrderId { get; set; }

    public int? ReservationId { get; set; }

    public int? ServiceId { get; set; }

    public int Quantity { get; set; }

    public DateOnly OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual Reservation? Reservation { get; set; }

    public virtual Service? Service { get; set; }

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? ReservationId { get; set; }

    public DateOnly PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public int PaymentMethodId { get; set; }

    public int StatusId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }

    public virtual PaymentStatus Status { get; set; } = null!;

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class SpecialRequest
{
    public int RequestId { get; set; }

    public int? ReservationId { get; set; }

    public DateOnly RequestDate { get; set; }

    public string? Description { get; set; }

    public int StatusId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual Reservation? Reservation { get; set; }

    public virtual RequestStatus Status { get; set; } = null!;

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? GuestId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public DateOnly ReservationDate { get; set; }

    public int NumberOfGuests { get; set; }

    public decimal TotalAmount { get; set; }

    public int StatusId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Room? Room { get; set; }

    public virtual ICollection<RoomServiceOrder> RoomServiceOrders { get; set; } = new List<RoomServiceOrder>();

    public virtual ICollection<SpecialRequest> SpecialRequests { get; set; } = new List<SpecialRequest>();

    public virtual ReservationStatus Status { get; set; } = null!;

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

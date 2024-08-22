using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int? RoomTypeId { get; set; }

    public int? Floor { get; set; }

    public string? Description { get; set; }

    public decimal PricePerNight { get; set; }

    public int StatusId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<RoomHistory> RoomHistories { get; set; } = new List<RoomHistory>();

    public virtual RoomType? RoomType { get; set; }

    public virtual RoomStatus Status { get; set; } = null!;

    public virtual SystemUser? UpdatedByNavigation { get; set; }

    public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
}

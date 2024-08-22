using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual ICollection<RoomServiceOrder> RoomServiceOrders { get; set; } = new List<RoomServiceOrder>();

    public virtual ICollection<ServiceInventory> ServiceInventories { get; set; } = new List<ServiceInventory>();

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

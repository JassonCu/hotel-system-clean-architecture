using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class ServiceInventory
{
    public int ServiceId { get; set; }

    public int InventoryId { get; set; }

    public int QuantityUsed { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual Inventory Inventory { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

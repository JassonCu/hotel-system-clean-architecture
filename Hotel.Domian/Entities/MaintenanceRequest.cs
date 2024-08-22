using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class MaintenanceRequest
{
    public int RequestId { get; set; }

    public int? RoomId { get; set; }

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

    public virtual Room? Room { get; set; }

    public virtual MaintenanceStatus Status { get; set; } = null!;

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

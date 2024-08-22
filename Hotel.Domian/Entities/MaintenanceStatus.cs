using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class MaintenanceStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();
}

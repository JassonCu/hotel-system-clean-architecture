using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class RequestStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<SpecialRequest> SpecialRequests { get; set; } = new List<SpecialRequest>();
}

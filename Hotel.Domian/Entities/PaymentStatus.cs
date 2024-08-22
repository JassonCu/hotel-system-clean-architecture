using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class PaymentStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

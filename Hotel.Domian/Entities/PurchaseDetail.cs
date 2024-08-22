using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class PurchaseDetail
{
    public int PurchaseDetailId { get; set; }

    public int? PurchaseId { get; set; }

    public string? ItemName { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Purchase? Purchase { get; set; }
}

using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class EmergencyContact
{
    public int ContactId { get; set; }

    public int? GuestId { get; set; }

    public string ContactName { get; set; } = null!;

    public string? ContactPhone { get; set; }

    public string? Relationship { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

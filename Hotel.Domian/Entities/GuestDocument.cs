using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class GuestDocument
{
    public int DocumentId { get; set; }

    public int? GuestId { get; set; }

    public string DocumentType { get; set; } = null!;

    public string DocumentPath { get; set; } = null!;

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

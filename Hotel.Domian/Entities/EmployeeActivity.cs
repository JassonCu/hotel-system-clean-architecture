using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class EmployeeActivity
{
    public int ActivityId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly ActivityDate { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class EmployeeDepartment
{
    public int EmployeeId { get; set; }

    public int DepartmentId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SystemUser? CreatedByNavigation { get; set; }

    public virtual SystemUser? DeletedByNavigation { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual SystemUser? UpdatedByNavigation { get; set; }
}

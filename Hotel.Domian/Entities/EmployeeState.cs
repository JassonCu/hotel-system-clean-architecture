using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class EmployeeState
{
    public int EmployeeStateId { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

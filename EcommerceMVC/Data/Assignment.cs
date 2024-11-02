using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public DateTime? DateAssign { get; set; }

    public bool? IsActive { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}

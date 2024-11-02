﻿using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Department
{
    public string DepartmentId { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public string? Information { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<Authorization> Authorizations { get; set; } = new List<Authorization>();
}

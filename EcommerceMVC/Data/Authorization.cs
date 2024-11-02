using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Authorization
{
    public int AuthorizationId { get; set; }

    public string? DepartmentId { get; set; }

    public int? WebsiteId { get; set; }

    public bool Add { get; set; }

    public bool Edit { get; set; }

    public bool Delete { get; set; }

    public bool View { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Website? Website { get; set; }
}

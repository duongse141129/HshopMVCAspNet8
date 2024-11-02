using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class QuestionAndAnswer
{
    public int Qaid { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public DateOnly DateQuestion { get; set; }

    public string EmployeeId { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}

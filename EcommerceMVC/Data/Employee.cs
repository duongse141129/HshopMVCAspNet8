using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<QuestionAndAnswer> QuestionAndAnswers { get; set; } = new List<QuestionAndAnswer>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}

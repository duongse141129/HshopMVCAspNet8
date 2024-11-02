using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Tracking
{
    public int TrackingId { get; set; }

    public string TrackingName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

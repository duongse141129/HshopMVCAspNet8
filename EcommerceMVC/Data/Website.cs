using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Website
{
    public int WebsiteId { get; set; }

    public string WebsiteName { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<Authorization> Authorizations { get; set; } = new List<Authorization>();
}

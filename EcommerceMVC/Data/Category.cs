using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? AliasDomain { get; set; }

    public string? Description { get; set; }

    public string? CategoryPhoto { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

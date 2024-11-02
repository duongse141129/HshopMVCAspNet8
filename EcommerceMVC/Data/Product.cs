using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? AliasDomain { get; set; }

    public int CategoryId { get; set; }

    public string? Unit { get; set; }

    public double? Price { get; set; }

    public string? ProductPhoto { get; set; }

    public DateTime Mfg { get; set; }

    public double Discount { get; set; }

    public int ViewCount { get; set; }

    public string? Description { get; set; }

    public string SupplierId { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Friend> Friends { get; set; } = new List<Friend>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}

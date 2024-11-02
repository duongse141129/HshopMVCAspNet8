using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Wishlist
{
    public int WishlistId { get; set; }

    public int? ProductId { get; set; }

    public string? CustomerId { get; set; }

    public DateTime? DatePick { get; set; }

    public string? Description { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}

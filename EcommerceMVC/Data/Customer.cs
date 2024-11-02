using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? Password { get; set; }

    public string FullName { get; set; } = null!;

    public bool IsMale { get; set; }

    public DateTime DayOfBirth { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string? Avatar { get; set; }

    public bool IsActive { get; set; }

    public int Role { get; set; }

    public string? RandomKey { get; set; }

    public virtual ICollection<Friend> Friends { get; set; } = new List<Friend>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}

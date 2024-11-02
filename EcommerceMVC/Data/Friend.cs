using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Friend
{
    public int FriendId { get; set; }

    public string? CustomerId { get; set; }

    public int ProductId { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; } = null!;

    public DateTime DateSend { get; set; }

    public string? Note { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product Product { get; set; } = null!;
}

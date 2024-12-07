using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Order
{
    public int OrderId { get; set; }

    public string CustomerId { get; set; } = null!;

    public DateTime DateOrder { get; set; }

    public DateTime? DateWeighing { get; set; }

    public DateTime? DateDelivery { get; set; }

    public string? FullName { get; set; }

    public string AddressDelivery { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string DeliveryMethod { get; set; } = null!;

    public double FreightCost { get; set; }

    public int TrackingId { get; set; }

    public string? EmployeeId { get; set; }

    public string? Note { get; set; }

    public string? PhoneDelivery { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Tracking Tracking { get; set; } = null!;
}

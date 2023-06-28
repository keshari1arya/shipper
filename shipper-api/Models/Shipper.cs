using System;
using System.Collections.Generic;

namespace shipper_api.Models;

public partial class Shipper
{
    public int ShipperId { get; set; }

    public string ShipperName { get; set; } = null!;

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}

using System;
using System.Collections.Generic;

namespace shipper_api.Models;

public partial class Carrier
{
    public int CarrierId { get; set; }

    public string CarrierName { get; set; } = null!;

    public string CarrierMode { get; set; } = null!;

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}

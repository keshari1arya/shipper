namespace shipper_api.Models;

public class ShipperShipmentDetails_Result
{
    public int ShipmentId { get; set; }
    public string ShipperName { get; set; }
    public string CarrierName { get; set; }
    public string ShipmentDescription { get; set; }
    public decimal ShipmentWeight { get; set; }
    public string ShipmentRateDescription { get; set; }
}

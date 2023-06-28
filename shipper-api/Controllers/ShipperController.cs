using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shipper_api.Models;

namespace shipper_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly ShipperContext context;

        public ShipperController(ShipperContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            return Ok(context.Shippers.OrderBy(x=>x.ShipperName).ToList());
        }

        [HttpGet("{shipperId}/shipment-details")]
        public async Task<IActionResult> ShipmentDetails(int shipperId)
        {
            var value =  this.context.SP_ShipperShipmentDetails(shipperId);
            return base.Ok(value);
        }
    }
}

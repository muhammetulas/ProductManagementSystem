using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.DBContext;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDataController : ControllerBase
    {
        private readonly ILogger<OrderDataController> _logger;

        private readonly IOrderDataAccess _orderDataAccess;

        public OrderDataController(ILogger<OrderDataController> logger, IOrderDataAccess  orderDataAccess)
        {
            _logger = logger;
            _orderDataAccess = orderDataAccess;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Order order)
        {
            _orderDataAccess.SaveOrder(order);

            return Ok("Success");
        }
    }
}
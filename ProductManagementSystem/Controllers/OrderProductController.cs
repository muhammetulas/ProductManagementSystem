using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.DBContext;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderProductController : ControllerBase
    {
        private readonly ILogger<OrderProductController> _logger;

        private readonly IOrderProductDataAccess _orderProductDataAccess;

        public OrderProductController(ILogger<OrderProductController> logger, IOrderProductDataAccess  orderProductDataAccess)
        {
            _logger = logger;
            _orderProductDataAccess = orderProductDataAccess;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] OrderProduct orderProduct)
        {
            _orderProductDataAccess.SaveOrderProduct(orderProduct);

            return Ok("Success");
        }
    }
}
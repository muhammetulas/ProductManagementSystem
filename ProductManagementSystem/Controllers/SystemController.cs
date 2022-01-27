using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.DBContext;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ILogger<SystemController> _logger;

        private readonly ICategoryDataAccess _categoryDataAccess;
        private readonly IOrderDataAccess _orderDataAccess;
        private readonly IOrderProductDataAccess _orderProductDataAccess;
        private readonly IProductDataAccess _productDataAccess;
        private readonly IService _service;

        public SystemController(
            ILogger<SystemController> logger,
            ICategoryDataAccess categoryDataAccess,
            IOrderDataAccess orderDataAccess,
            IOrderProductDataAccess orderProductDataAccess,
            IProductDataAccess productDataAccess,
            IService service
            )
        {
            _logger = logger;
            _categoryDataAccess = categoryDataAccess;
            _orderDataAccess = orderDataAccess;
            _orderProductDataAccess = orderProductDataAccess;
            _productDataAccess = productDataAccess;
            _service = service;
        }

        [HttpGet("GetProductsOfCategoryAndDescendants")]
        public IActionResult GetDatas(int categoryID)
        {
            return Ok(_service.GetProductsOfCategoryAndDescendants(categoryID));
        }

        [HttpPost("getOrderStatistics")]
        public IActionResult GetDatas([FromBody] List<Entities.Orders> orders)
        {
            return Ok(_service.GetOrderStatistics(orders));
        }
    }
}
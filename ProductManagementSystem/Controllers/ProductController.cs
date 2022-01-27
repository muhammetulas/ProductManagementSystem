using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.DBContext;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private readonly IProductDataAccess _productDataAccess;

        public ProductController(ILogger<ProductController> logger, IProductDataAccess productDataAccess)
        {
            _logger = logger;
            _productDataAccess = productDataAccess;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Product product)
        {
            _productDataAccess.SaveProduct(product);

            return Ok("Success");
        }
    }
}
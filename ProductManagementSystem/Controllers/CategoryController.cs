using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.DBContext;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly ICategoryDataAccess _categoryDataAccess;

        public CategoryController(ILogger<CategoryController> logger, ICategoryDataAccess  categoryDataAccess)
        {
            _logger = logger;
            _categoryDataAccess = categoryDataAccess;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Category category)
        {
            _categoryDataAccess.SaveCategory(category);

            return Ok("Success");
        }
    }
}
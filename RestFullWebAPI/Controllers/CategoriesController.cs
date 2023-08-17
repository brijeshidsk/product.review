using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestFullWebAPI.Models;
using RestFullWebAPI.Repositories;
using RestFullWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestFullWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IDataService<Category> _service;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IDataService<Category> service, ILogger<CategoriesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public List<Category> Get()
        {
            _logger.LogInformation("Categories's are listed");
            var categories = _service.Get();

            return categories;

        }

        // GET: api/<CategoriesController>/1
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            _logger.LogInformation("Category");
            var category = _service.Get(id);

            return category;

        }

    }
}

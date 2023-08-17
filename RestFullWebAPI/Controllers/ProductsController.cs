using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestFullWebAPI.Models;
using RestFullWebAPI.Models.DTO;
using RestFullWebAPI.Repositories;
using RestFullWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestFullWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDataService<Product> _service;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductDataService<Product> service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _service.Get(id);

            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {

            var id = _service.create(product);

            return CreatedAtRoute("GetById", new { id = product.Id }, product);

        }

        //GET: api/<ProductsController>
        [HttpGet]
        public List<Product> Get()
        {
            var products = _service.Get();

            return products;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {

            try
            {
                _service.Update(id, product);
                //return HttpStatusCode.NoContent;
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }

        }
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");

            }

        }


        [HttpPost("reviews")]
        public IActionResult Reviews([FromBody] Review review)
        {

            try
            {
                var product = _service.reviews(review);

                return CreatedAtRoute("GetById", new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }

        }
    }
}

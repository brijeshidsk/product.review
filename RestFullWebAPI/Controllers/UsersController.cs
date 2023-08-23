using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestFullWebAPI.Models;
using RestFullWebAPI.Models.DTO;
using RestFullWebAPI.Repositories;
using RestFullWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestFullWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserDataService<User> _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserDataService<User> service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                _logger.LogInformation("User's are listed");
                var users = _service.Get();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}" , Name = "GetById")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _service.Get(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User  user)
        {

            try
            {
                var id = _service.create(user);


                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginParam loginparam)
        {

            try
            {
                var user = _service.login(loginparam);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {

            try
            {
                _service.Update(id, user);
                //return HttpStatusCode.NoContent;
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.delete(id);

                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(500, "Internal server error!");

            }

        }
    }
}

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
        public List<User> Get()
        {

            _logger.LogInformation("User's are listed");
            var users = _service.Get();

            return users;

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}" , Name = "GetById")]
        public User Get(int id)
        {
            var user = _service.Get(id);

            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User  user)
        {

            var id = _service.create(user);

            return CreatedAtRoute("GetById", new {id = user.Id}, user);


        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginParam loginparam)
        {

            try
            {
                var user = _service.login(loginparam);

                return CreatedAtRoute("GetById", new { id = user.Id }, user);
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
                return CreatedAtRoute("GetById", new { id = user.Id }, user);
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

                return NoContent();
            }catch(Exception ex)
            {
                return StatusCode(500, "Internal server error!");

            }

        }
    }
}

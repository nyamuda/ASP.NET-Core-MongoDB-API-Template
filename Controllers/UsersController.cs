using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult>  GetUsers()
        {
            var allUsers = await _userService.GetUsers();
            return Ok(allUsers);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult>  GetUser(string id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.AddUser(user);

            return CreatedAtAction(nameof(_userService.GetUser), new { id = user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            await _userService.UpdateUser(id, user);
            return Ok(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            bool isSuccess = await _userService.DeleteUser(id);
            if (isSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

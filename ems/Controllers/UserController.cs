using ems.Models;
using ems.Models.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) {

            this.userService = userService;
        }


        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> GetUser()
        {
            return userService.GetUser();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = userService.Get(id);
            if (user == null)
            {
                return NotFound($"user with  Id = {id} Not Found");
            }
            return user;
        }




        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody]  User user)
        {
            userService.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }



        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {

            var existingUser = userService.Get(id);
            if (existingUser == null)
            {
                return NotFound($"user with Id = {id} not found");
            }

            existingUser.Update(id, user);

            return NoContent();
        }




        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {

            var user = userService.Get(id);
            if (user == null)
            {
                return NotFound($"user with Id = {id} not found");
            }
            userService.Remove(user.Id);

            return Ok($"user with id = {id} deleted");
        }
    }
}

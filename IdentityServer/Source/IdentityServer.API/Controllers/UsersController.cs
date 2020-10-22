using System.Collections.Generic;
using System.Linq;
using IdentityServer.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;

        public UsersController(AppDbContext context) => this.context = context;

        [HttpGet]
        public IEnumerable<AppUser> Get()
        {
            return context.Users;
        }

        [HttpGet("{id}")]
        public AppUser Get(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] string firstName, [FromBody] string lastName)
        {
            context.Users.Add(new AppUser
            {
                FirstName = firstName,
                LastName = lastName,
            });
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string firstName, [FromBody] string lastName)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            user.FirstName = firstName;
            user.LastName = lastName;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            context.Remove(user);
            context.SaveChanges();
        }
    }
}
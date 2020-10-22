using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using User.API.Models;

namespace User.API.Controllers
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
        public void Post([FromBody] UpdateModel model)
        {
            context.Users.Add(new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            });
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UpdateModel model)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
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
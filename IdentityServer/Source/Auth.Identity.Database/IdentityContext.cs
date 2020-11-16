using Auth.Identity.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Auth.Identity.Database
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
    }
}
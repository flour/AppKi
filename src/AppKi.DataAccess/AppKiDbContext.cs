using AppKi.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppKi.DataAccess;

public class AppKiDbContext : IdentityDbContext<AppKiUser, AppKiUserRole, int>
{
    public AppKiDbContext(DbContextOptions<AppKiDbContext> options) : base(options)
    {
    }
}
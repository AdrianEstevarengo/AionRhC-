using AionRhC_.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AionRhC_.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  { }
        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}

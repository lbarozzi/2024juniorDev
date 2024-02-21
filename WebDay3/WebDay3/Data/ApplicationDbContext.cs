using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebDay3.Models;

namespace WebDay3.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<WebDay3.Models.Appointment> Appointment { get; set; } = default!;
    }
}

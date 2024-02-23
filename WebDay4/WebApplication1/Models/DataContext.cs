using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> opt) :base(opt) { }

        public DbSet<Student> Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using WebDay2.Models;


namespace WebDay2.Models {
    public class DataContext:DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<WebDay2.Models.ClassRoom> ClassRoom { get; set; } = default!;
    }
}

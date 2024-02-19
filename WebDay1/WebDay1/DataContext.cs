using Microsoft.EntityFrameworkCore;

namespace WebDay1 {
    public partial class DataContext:DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
    }
}

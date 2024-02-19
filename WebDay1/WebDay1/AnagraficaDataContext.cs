using Microsoft.EntityFrameworkCore;

namespace WebDay1 {
    public partial class DataContext {
        public DbSet<Anagrafica> Anagrafiche { get; set; }
    }
}

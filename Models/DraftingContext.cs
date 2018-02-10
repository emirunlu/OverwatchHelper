using Microsoft.EntityFrameworkCore;

namespace owdrafter.Models
{
    public class MDraftingContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Draft> Drafts { get; set; }
    }
}
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace owdrafter.Models
{
    public class DrafterDbContext : DbContext
    {
        public DrafterDbContext(DbContextOptions<DrafterDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
    }
}
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace owdrafter.Models
{
    public class DrafterDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
    }
}
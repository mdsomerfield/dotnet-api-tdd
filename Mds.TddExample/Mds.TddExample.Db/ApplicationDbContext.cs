using Mds.TddExample.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mds.TddExample.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Helicopter> Helicopters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}

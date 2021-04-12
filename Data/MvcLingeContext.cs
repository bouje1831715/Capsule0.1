using Microsoft.EntityFrameworkCore;
using MvcLinge.Models;

namespace MvcLinge.Data
{
    public class MvcLingeContext : DbContext
    {
        public MvcLingeContext(DbContextOptions<MvcLingeContext> options)
            : base(options)
        {
        }

        public DbSet<Linge> Linge { get; set; }
    }
}
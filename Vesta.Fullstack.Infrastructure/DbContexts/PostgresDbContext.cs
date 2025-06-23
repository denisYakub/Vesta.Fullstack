using Microsoft.EntityFrameworkCore;
using Vesta.Fullstack.Domain.Entities;

namespace Vesta.Fullstack.Infrastructure.DbContexts
{
    public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; private set; }
    }
}

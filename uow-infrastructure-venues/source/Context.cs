using Microsoft.EntityFrameworkCore;

namespace Uow.Infrastructure.Venues;

public class Context : DbContext
{
    public DbSet<Concert> Concert { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(
            "Data Source=BECKY\\SQLEXPRESS;Initial Catalog=Venues;Integrated Security=SSPI;Encrypt=False"
        );
    }
}

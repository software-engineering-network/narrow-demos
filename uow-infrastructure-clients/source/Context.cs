using Microsoft.EntityFrameworkCore;

namespace Uow.Infrastructure.Clients;

public class Context : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Reservation> Reservation { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(
            "Data Source=BECKY\\SQLEXPRESS;Initial Catalog=Clients;Integrated Security=SSPI;Encrypt=False"
        );
    }
}

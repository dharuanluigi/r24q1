using Microsoft.EntityFrameworkCore;
using r24q1.Entity;

namespace r24q1.Contexts;

public class ClientContext : DbContext
{
    public DbSet<Client>? Clients { get; set; }

    public DbSet<Transaction>? Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging()
        .UseMySQL("server=localhost;uid=root;pwd=Brasil123;database=r24q1;sslmode=none;");
    }
}
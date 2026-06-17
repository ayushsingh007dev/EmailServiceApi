using EmailServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailServiceApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<EmailLog> EmailLogs { get; set; }
}
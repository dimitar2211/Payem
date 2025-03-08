using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Payem.Models;

namespace Payem.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<PaymentList> PaymentList { get; set; }

   // public DbSet<Payem.Models.PaymentList> PaymentList { get; set; } = default!;
}


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace InterViewWebApp.Model
{
    public class shopDbContext:DbContext
    {
        public shopDbContext(DbContextOptions<shopDbContext> options): base(options) { }

        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Unit> Units { get; set; }

    }
}

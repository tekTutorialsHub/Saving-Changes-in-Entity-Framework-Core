using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;


namespace EFCoreCRUD
{
    public partial class EFCoreContext : DbContext
    {


        public static readonly ILoggerFactory MyLoggerFactory =
            LoggerFactory.Create(
                    builder => {
                        builder.AddConsole().AddFilter((d,l) => d==DbLoggerCategory.Database.Command.Name && l==LogLevel.Information);
                    });

        public EFCoreContext()
        {
        }

        public EFCoreContext(DbContextOptions<EFCoreContext> options)  : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(MyLoggerFactory)
                    .UseSqlServer("Server=LOCALHOST;Database=EFCoreCrud;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

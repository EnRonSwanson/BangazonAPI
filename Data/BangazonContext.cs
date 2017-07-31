using Microsoft.EntityFrameworkCore;
using BangazonAPI.Models;

namespace BangazonAPI.Data
{
    public class BangazonContext : DbContext
    {
        public BangazonContext(DbContextOptions<BangazonContext> options)
            : base(options)
        { }
        //THESE ARE THE TABLES THAT ARE GOING IN THE DATABASE
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<TrainingPgmEmp> TrainingPgmEmp { get; set; }
        public DbSet<TrainingProgram> TrainingProgram { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ComputerEmployee> ComputerEmployee { get; set; }
        public DbSet<Computer> Computer { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        }
    }
}

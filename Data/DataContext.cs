using CTPortaria.Data.Mappings;
using CTPortaria.Entities;
using Microsoft.EntityFrameworkCore;

namespace CTPortaria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<GateLogModel> GateLogs { get; set; }
        public DbSet<VisitorModel> Visitors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new GateLogMap());
            modelBuilder.ApplyConfiguration(new VisitorMap());
        }
    }
}

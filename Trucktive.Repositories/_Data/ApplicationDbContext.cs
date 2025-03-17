using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trucktive.Core.Entities;

namespace Trucktive.Repositories._Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverBehavior> DriverBehaviors { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Company> Companies { get; set; }

    }
}

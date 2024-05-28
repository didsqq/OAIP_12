using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;


namespace OAIP_12
{
    public class AppDbContext: DbContext
    {
        private const string ConnectionString = "DataSource=DESKTOP-T0VR3FD\\SQLEXPRESS;Initial Catalog = LibraryDb; IntegratedSecurity = True;";
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasMany(u => u.Orders)
            .WithOne(b => b.Customer)
            .HasForeignKey(b => b.CustomerID);
        }

    }
}

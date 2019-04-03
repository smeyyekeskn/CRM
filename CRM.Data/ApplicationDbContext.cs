using CRM.Data.Builders;
using CRM.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CustomerBuilder(modelBuilder.Entity<Customer>());
            new CategoryBuilder(modelBuilder.Entity<Category>());
            new EmployeeBuilder(modelBuilder.Entity<Employee>());
            new OfferBuilder(modelBuilder.Entity<Offer>());
            new ProductBuilder(modelBuilder.Entity<Product>());
            new RegionBuilder(modelBuilder.Entity<Region>());
            new OrderItemBuilder(modelBuilder.Entity<OrderItem>());
        }
        
    }
    
}

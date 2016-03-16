using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Intercity.Models
{
    public class ManifestContext : DbContext
    {
        public ManifestContext() : base("name = DefaultConnection") { }
        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Receiver> Receivers { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Pickup> Pickups { get; set; }
    }
}
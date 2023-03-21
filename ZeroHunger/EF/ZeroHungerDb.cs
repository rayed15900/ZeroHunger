using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZeroHunger.EF.Models;

namespace ZeroHunger.EF
{
    public class ZeroHungerDb : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
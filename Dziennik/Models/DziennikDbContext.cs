using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class DziennikDbContext : DbContext
    {
        public DziennikDbContext() : base("MyConnectionString") { }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
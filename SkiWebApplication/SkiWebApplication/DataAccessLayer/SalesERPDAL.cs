using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SkiWebApplication.Models;

namespace SkiWebApplication.DataAccessLayer
{
    public class SalesERPDAL : DbContext
    {
        public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            Database.SetInitializer<SalesERPDAL>(null);
            base.OnModelCreating(modelBuilder);
        }
    }

}
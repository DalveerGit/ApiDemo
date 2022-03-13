
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApiWithSwagger.Enumarations;
using DemoWebApiWithSwagger.Models;
using Microsoft.EntityFrameworkCore;


namespace DemoWebApiWithSwagger.Context
{
    public class AppDBContext: DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        { 
        
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(new Employee { 
               Id = 1,   
               Name ="Dalveer Singh",
               Age =28,
               Address ="Nihal Vihar",
               Gender = Enums.Gender.Male

            });

        }
    }
}

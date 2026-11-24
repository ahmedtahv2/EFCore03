using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.AppContext
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=EFcore03;trusted_connection=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }
        public DbSet<Category> Categorie{ get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

    }
}

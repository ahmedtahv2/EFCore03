using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Configurations
{
    internal class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> c)
        {
            c.HasKey(c => c.CourseID);

            c.Property(c => c.Title).IsRequired().HasMaxLength(100);

            c.Property(c => c.Descriprion).HasMaxLength(500);

            c.Property(c => c.Price).HasPrecision(18, 2);

            //instructor relation
            c.HasOne(c => c.Instructor)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.InstructorId);

            c.HasData(
    new Course
    {
        CourseID = 1,
        Title = "C# Fundamentals",
        Descriprion = "Learn C# from scratch",
        Price = 500m,
        Level = Level.Beginner,
        Flag = true,
        PublishedDate = new DateTime(2025, 1, 1),
        InstructorId = 1,
        CategorieID = 2
    },
    new Course
    {
        CourseID = 2,
        Title = "ASP.NET Core",
        Descriprion = "Build Web Applications",
        Price = 1500m,
        Level = Level.Intermediate,
        Flag = true,
        PublishedDate = new DateTime(2025, 2, 1),
        InstructorId = 1,
        CategorieID = 4
    },
    new Course
    {
        CourseID = 3,
        Title = "HTML and CSS",
        Descriprion = "Frontend Fundamentals",
        Price = 300m,
        Level = Level.Beginner,
        Flag = true,
        PublishedDate = new DateTime(2025, 3, 1),
        InstructorId = 2,
        CategorieID = 3
    },
    new Course
    {
        CourseID = 4,
        Title = "SQL Server",
        Descriprion = "Database Fundamentals",
        Price = 800m,
        Level = Level.Beginner,
        Flag = true,
        PublishedDate = new DateTime(2025, 4, 1),
        InstructorId = 3,
        CategorieID = 6
    },
    new Course
    {
        CourseID = 5,
        Title = "Entity Framework Core",
        Descriprion = "Advanced Database Operations",
        Price = 1200m,
        Level = Level.Advanced,
        Flag = false,
        PublishedDate = null,
        InstructorId = 1,
        CategorieID = 4
    },
    new Course
    {
        CourseID = 6,
        Title = "Advanced SQL",
        Descriprion = "Advanced SQL Queries",
        Price = 2000m,
        Level = Level.Advanced,
        Flag = false,
        PublishedDate = null,
        InstructorId = 3,
        CategorieID = 6
    }
);
        }
    }
}

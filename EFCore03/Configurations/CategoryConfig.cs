using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Configurations
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> c)
        {
            c.HasKey(c => c.CategorieID);

            c.Property(c => c.Name).IsRequired().HasMaxLength(100);

            c.Property(c => c.Description).HasMaxLength(500);

            //course relation
            c.HasMany(c => c.Courses)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategorieID);

            //category relation
            c.HasOne(c => c.ParentCategory)
                .WithMany(c => c.Categories)
                .HasForeignKey(c => c.CategorieParentID)
                .OnDelete(DeleteBehavior.Restrict);

            c.HasData(
    new Category
    {
        CategorieID = 1,
        Name = "Programming",
        Description = "Software Development",
        CategorieParentID = null
    },
    new Category
    {
        CategorieID = 2,
        Name = "Backend",
        Description = "Server Side Development",
        CategorieParentID = 1
    },
    new Category
    {
        CategorieID = 3,
        Name = "Frontend",
        Description = "Client Side Development",
        CategorieParentID = 1
    },
    new Category
    {
        CategorieID = 4,
        Name = "ASP.NET",
        Description = "ASP.NET Development",
        CategorieParentID = 2
    },
    new Category
    {
        CategorieID = 5,
        Name = "Database",
        Description = "Database Development",
        CategorieParentID = null
    },
    new Category
    {
        CategorieID = 6,
        Name = "SQL Server",
        Description = "Microsoft SQL Server",
        CategorieParentID = 5
    },
    new Category
    {
        CategorieID = 7,
        Name = "Design",
        Description = "UI and UX Design",
        CategorieParentID = null
    }
);
        }
    }
}

using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Configurations
{
    internal class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> i)
        {
            i.HasKey(c => c.InstructorID);

            i.Property(c => c.FullName).IsRequired().HasMaxLength(300);

            i.Property(c => c.Email).IsRequired().HasMaxLength(150);

            i.Property(c => c.Bio).HasMaxLength(300);

            i.Property(c => c.JoinedDate).IsRequired();

            i.HasData(
    new Instructor
    {
        InstructorID = 1,
        FullName = "Ahmed Mohamed",
        Email = "ahmed@example.com",
        Bio = "Backend Developer",
        JoinedDate = new DateTime(2024, 1, 10)
    },
    new Instructor
    {
        InstructorID = 2,
        FullName = "Omar Hassan",
        Email = "omar@example.com",
        Bio = "Frontend Developer",
        JoinedDate = new DateTime(2024, 3, 15)
    },
    new Instructor
    {
        InstructorID = 3,
        FullName = "Sara Ali",
        Email = "sara@example.com",
        Bio = "Database Engineer",
        JoinedDate = new DateTime(2024, 6, 20)
    }
);


        }
    }
}

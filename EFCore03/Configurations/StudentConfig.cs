using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Configurations
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> s)
        {
            s.HasKey(c => c.StudentID);
            s.Property(c => c.Name).IsRequired().HasMaxLength(100);

            s.Property(c => c.Email).IsRequired().HasMaxLength(300);

            s.Property(c => c.DateOfBirth).IsRequired();

            s.HasData(
    new Student
    {
        StudentID = 1,
        Name = "Youssef Ahmed",
        Email = "youssef@example.com",
        DateOfBirth = new DateTime(2004, 5, 10)
    },
    new Student
    {
        StudentID = 2,
        Name = "Mohamed Ali",
        Email = "mohamed@example.com",
        DateOfBirth = new DateTime(2003, 8, 15)
    },
    new Student
    {
        StudentID = 3,
        Name = "Mostafa Hassan",
        Email = "mostafa@example.com",
        DateOfBirth = new DateTime(2005, 2, 20)
    },
    new Student
    {
        StudentID = 4,
        Name = "Mariam Adel",
        Email = "mariam@example.com",
        DateOfBirth = new DateTime(2004, 9, 12)
    },
    new Student
    {
        StudentID = 5,
        Name = "Nour Ibrahim",
        Email = "nour@example.com",
        DateOfBirth = new DateTime(2003, 11, 25)
    }
);
        }
    }
}

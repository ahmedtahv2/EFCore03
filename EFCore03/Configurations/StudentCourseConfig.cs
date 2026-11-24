using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Configurations
{
    internal class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> s)
        {
            s.HasKey(s => new { s.StudentID, s.CourseID });

            s.Property(s => s.FinalGradde).HasPrecision(5, 2);

            s.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Progress",
                    "[ProgressPercentage] BETWEEN 0 AND 100");

                t.HasCheckConstraint(
                    "CK_FinalGrade",
                    "[FinalGradde] IS NULL OR [Status] = 1");

                t.HasCheckConstraint(
                    "CK_Completed",
                    "[ProgressPercentage] <> 100 OR [Status] = 1");
            });


            //relation with student
            s.HasOne(s => s.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.StudentID);

            //relation with course
            s.HasOne(s => s.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.CourseID)
                .OnDelete(DeleteBehavior.Cascade);

            s.HasData(
    new StudentCourse
    {
        StudentID = 1,
        CourseID = 1,
        EnrollmentDate = new DateTime(2025, 5, 1),
        ProgressPercentage = 50,
        Status = Status.Active,
        FinalGradde = null
    },
    new StudentCourse
    {
        StudentID = 1,
        CourseID = 2,
        EnrollmentDate = new DateTime(2025, 5, 2),
        ProgressPercentage = 100,
        Status = Status.Completed,
        FinalGradde = 95.50m
    },
    new StudentCourse
    {
        StudentID = 2,
        CourseID = 1,
        EnrollmentDate = new DateTime(2025, 5, 3),
        ProgressPercentage = 25,
        Status = Status.Active,
        FinalGradde = null
    },
    new StudentCourse
    {
        StudentID = 2,
        CourseID = 3,
        EnrollmentDate = new DateTime(2025, 5, 4),
        ProgressPercentage = 100,
        Status = Status.Completed,
        FinalGradde = 88.75m
    },
    new StudentCourse
    {
        StudentID = 3,
        CourseID = 1,
        EnrollmentDate = new DateTime(2025, 5, 5),
        ProgressPercentage = 10,
        Status = Status.Dropped,
        FinalGradde = null
    },
    new StudentCourse
    {
        StudentID = 3,
        CourseID = 4,
        EnrollmentDate = new DateTime(2025, 5, 6),
        ProgressPercentage = 75,
        Status = Status.Active,
        FinalGradde = null
    },
    new StudentCourse
    {
        StudentID = 4,
        CourseID = 2,
        EnrollmentDate = new DateTime(2025, 5, 7),
        ProgressPercentage = 0,
        Status = Status.Active,
        FinalGradde = null
    },
    new StudentCourse
    {
        StudentID = 4,
        CourseID = 4,
        EnrollmentDate = new DateTime(2025, 5, 8),
        ProgressPercentage = 100,
        Status = Status.Completed,
        FinalGradde = 92.00m
    }
);
        }
    }
}

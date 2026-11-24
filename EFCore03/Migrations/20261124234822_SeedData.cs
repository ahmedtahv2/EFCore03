using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore03.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorie",
                columns: new[] { "CategorieID", "CategorieParentID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Software Development", "Programming" },
                    { 5, null, "Database Development", "Database" },
                    { 7, null, "UI and UX Design", "Design" }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "InstructorID", "Bio", "Email", "FullName", "JoinedDate" },
                values: new object[,]
                {
                    { 1, "Backend Developer", "ahmed@example.com", "Ahmed Mohamed", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Frontend Developer", "omar@example.com", "Omar Hassan", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Database Engineer", "sara@example.com", "Sara Ali", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentID", "DateOfBirth", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef@example.com", "Youssef Ahmed" },
                    { 2, new DateTime(2003, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed@example.com", "Mohamed Ali" },
                    { 3, new DateTime(2005, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mostafa@example.com", "Mostafa Hassan" },
                    { 4, new DateTime(2004, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam@example.com", "Mariam Adel" },
                    { 5, new DateTime(2003, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour@example.com", "Nour Ibrahim" }
                });

            migrationBuilder.InsertData(
                table: "Categorie",
                columns: new[] { "CategorieID", "CategorieParentID", "Description", "Name" },
                values: new object[,]
                {
                    { 2, 1, "Server Side Development", "Backend" },
                    { 3, 1, "Client Side Development", "Frontend" },
                    { 6, 5, "Microsoft SQL Server", "SQL Server" },
                    { 4, 2, "ASP.NET Development", "ASP.NET" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "CategorieID", "Descriprion", "Flag", "InstructorId", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Learn C# from scratch", true, 1, 0, 500m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals" },
                    { 3, 3, "Frontend Fundamentals", true, 2, 0, 300m, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML and CSS" },
                    { 4, 6, "Database Fundamentals", true, 3, 0, 800m, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Server" },
                    { 6, 6, "Advanced SQL Queries", false, 3, 2, 2000m, null, "Advanced SQL" },
                    { 2, 4, "Build Web Applications", true, 1, 1, 1500m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core" },
                    { 5, 4, "Advanced Database Operations", false, 1, 2, 1200m, null, "Entity Framework Core" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "CourseID", "StudentID", "EnrollmentDate", "FinalGradde", "ProgressPercentage", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50.0, 0 },
                    { 1, 2, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 25.0, 0 },
                    { 3, 2, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.75m, 100.0, 1 },
                    { 1, 3, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10.0, 2 },
                    { 4, 3, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 75.0, 0 },
                    { 4, 4, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.00m, 100.0, 1 },
                    { 2, 1, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.50m, 100.0, 1 },
                    { 2, 4, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "CategorieID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseID", "StudentID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "CategorieID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "CategorieID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "CategorieID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InstructorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InstructorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "InstructorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "CategorieID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "CategorieID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "CategorieID",
                keyValue: 1);
        }
    }
}

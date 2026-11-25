using EFCore03.AppContext;
using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Identity.Client.NativeInterop;

namespace EFCore03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //I couldn't figure out how to set the condition of progress an accept only published and CRUD conditions also
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            using AppDbContext dbContext = new AppDbContext();
            #region CRUD Operations

            #region Create Operations
            #region instructor
            Instructor instructor01 = new Instructor
            {
                FullName = "Ahmed Taha",
                Email = "taha@example.com",
                Bio = "Software Engineer",
                JoinedDate = DateTime.Now
            };
            dbContext.Instructor.Add(instructor01);
            await dbContext.SaveChangesAsync();
            Console.WriteLine($"instructor Added {instructor01.InstructorID}");
            #endregion

            #region Course
            Course course01 = new Course
            {
                Title = "Advanced LNQ",
                Descriprion = "Advanced LNQ Queries",
                Price = 2000m,
                Level = Level.Advanced,
                Flag = false,
                PublishedDate = null,
                InstructorId = 4,
                CategorieID = 6
            };
            dbContext.Course.Add(course01);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Course Added");
            #endregion

            #region Student
            List<Student> students01 = new List<Student>
            {
                new Student {Name = "Ahmed Ibrahim",Email = "Ahmed@example.com",DateOfBirth = new DateTime(2003, 11, 25)},
                new Student {Name = "ibrahim Ibrahim",Email = "ibragim@example.com",DateOfBirth = new DateTime(2003, 11, 25)},
                new Student {Name = "Loai Ibrahim",Email = "Loai@example.com",DateOfBirth = new DateTime(2003, 11, 25)}
            };
            dbContext.AddRange(students01);
            await dbContext.SaveChangesAsync();
            Console.WriteLine($"Students added {students01[0].StudentID},{students01[1].StudentID},{students01[2].StudentID}");
            #endregion

            #region Enroll
            StudentCourse enroll01 = new StudentCourse
            {
                StudentID = 6,
                CourseID = 1,
                EnrollmentDate = new DateTime(2025, 5, 5),
                ProgressPercentage = 10,
                Status = Status.Dropped,
                FinalGradde = null
            };
            dbContext.StudentCourse.Add(enroll01);
            await dbContext.SaveChangesAsync();
            #endregion
            #endregion

            #region Read Operations
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            #region Find Course
            var courseByID = await dbContext.Course.FindAsync(1);
            if (courseByID == null)
                Console.WriteLine("N/F");
            else
                Console.WriteLine($"title:{courseByID.Title}");
            var courseByTitle = await dbContext.Course.FirstOrDefaultAsync(c => c.Title == "C# Fundamentals");
            if (courseByTitle == null)
                Console.WriteLine("N/F");
            else
                Console.WriteLine("Course found");
            #endregion

            #region Filter Course
            var CoursesPrices = await dbContext.Course
                .Where(c => c.Price >= 100 && c.Price <= 1000)
                .OrderByDescending(c => c.Price)
                .Select(c => new { c.Title, c.Level, c.Price })
                .ToListAsync();
            Console.WriteLine("Courses:");
            foreach (var c in CoursesPrices)
            {
                Console.WriteLine($"{c.Title} | {c.Level} | {c.Price}");
            }
            #endregion

            #region SubCategories
            var parent = await dbContext.Categorie
        .FirstOrDefaultAsync(c => c.Name == "Programming");

            if (parent == null)
            {
                Console.WriteLine("Category not found");
            }
            else
            {
                var subCategories = await dbContext.Categorie
                    .Where(c => c.CategorieParentID == parent.CategorieID)
                    .ToListAsync();

                Console.WriteLine("Subcategories:");

                foreach (var category in subCategories)
                {
                    Console.WriteLine(category.Name);
                }
                var topCategories = await dbContext.Categorie
                    .Where(c => c.CategorieParentID == null)
                    .ToListAsync();

                Console.WriteLine("Top-Level Categories:");

                foreach (var category in topCategories)
                {
                    Console.WriteLine(category.Name);
                }
            }
            #endregion

            #region Course roster

            if (!await dbContext.Course.AnyAsync(c => c.CourseID == 1))
            {
                Console.WriteLine("Course not found");
            }
            else
            {
                var studentIds = await dbContext.StudentCourse
                    .Where(s => s.CourseID == 1)
                    .Select(s => s.StudentID)
                    .ToListAsync();

                Console.WriteLine($"Number of students: {studentIds.Count}");

                var studentNames = await dbContext.Student
                    .Where(s => studentIds.Contains(s.StudentID))
                    .Select(s => s.Name)
                    .ToListAsync();
                Console.WriteLine("Thier names:");
                foreach (var name in studentNames)
                {
                    Console.WriteLine(name);
                }
            }

            #endregion

            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            #endregion


            #endregion


        }
    }
}

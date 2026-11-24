using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore03.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; } = null!;
        public string? Descriprion { get; set; }
        public decimal Price { get; set; }
        public Level Level { get; set; }
        public bool Flag { get; set; }
        public DateTime? PublishedDate { get; set; }

        //instructor Relation 
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;

        //Category Relation 
        public int CategorieID { get; set; }    
        public Category Category { get; set; } = null!;

        //student Course Relation
        public ICollection<StudentCourse> StudentCourses { get; set; }= new HashSet<StudentCourse>();

    }
}

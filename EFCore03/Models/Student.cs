using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore03.Models
{
    public class Student
    {
        [Key]
        public int StudentID  { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        //student Course Relation
        public ICollection<StudentCourse> StudentCourses { get; set; }= new HashSet<StudentCourse>();
    }
}

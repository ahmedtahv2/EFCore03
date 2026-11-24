using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore03.Models
{
    public class StudentCourse
    {
        public DateTime EnrollmentDate { get; set; }
        [Range(0, 100)] //just to make sure
        public double ProgressPercentage { get; set; }
        public Status Status { get; set; }
        public decimal? FinalGradde { get; set; }

        //Relations
        public int StudentID { get; set; }
        public Student Student { get; set; } = null!;   
        public int CourseID { get; set; }
        public Course Course { get; set; } = null!;

    }
}

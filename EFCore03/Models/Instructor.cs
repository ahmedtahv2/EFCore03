using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore03.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Bio { get; set; }
        public DateTime JoinedDate{ get; set; }

        //Cousrse Relation
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>(); 
       
    }
}

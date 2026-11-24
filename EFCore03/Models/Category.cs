using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EFCore03.Models
{
    public class Category
    {
        public int CategorieID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        //Category Relation
        public int? CategorieParentID { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Category> Categories { get; set; }= new HashSet<Category>();

        //Coursen Relation 
        public ICollection<Course> Courses { get; set; }= new HashSet<Course>();
    }
}

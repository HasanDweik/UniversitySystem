using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class Course
    {
        public Course()
        {
            TeachersPerCourses = new HashSet<TeachersPerCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly StartDate { get; set; }
        public int Credits { get; set; }
        public string Faculty { get; set; } = null!;

        public virtual ICollection<TeachersPerCourse> TeachersPerCourses { get; set; }
    }
}

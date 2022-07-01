using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class User
    {
        public User()
        {
            StudentsPerClasses = new HashSet<StudentsPerClass>();
            TeachersPerCourses = new HashSet<TeachersPerCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<StudentsPerClass> StudentsPerClasses { get; set; }
        public virtual ICollection<TeachersPerCourse> TeachersPerCourses { get; set; }
    }
}

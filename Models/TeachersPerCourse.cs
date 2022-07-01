using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    /// <summary>
    /// Classes
    /// </summary>
    public partial class TeachersPerCourse
    {
        public TeachersPerCourse()
        {
            StudentsPerClasses = new HashSet<StudentsPerClass>();
        }

        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User Teacher { get; set; } = null!;
        public virtual ICollection<StudentsPerClass> StudentsPerClasses { get; set; }
    }
}

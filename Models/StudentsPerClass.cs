using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class StudentsPerClass
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public virtual TeachersPerCourse Class { get; set; } = null!;
        public virtual User Student { get; set; } = null!;
    }
}

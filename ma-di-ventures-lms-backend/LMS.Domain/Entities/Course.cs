using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Course
    {
        public int Id { get; private set; }
        public string CourseName { get; private set; } = string.Empty;
        public string CourseDescription { get; private set; } = string.Empty;
        public List<Lesson> Lessons { get; private set; } = new List<Lesson>();
    }
}

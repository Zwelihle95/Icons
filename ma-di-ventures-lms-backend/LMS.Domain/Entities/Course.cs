using LMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public int? InstructorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public CourseLevel Level { get; set; }
        public Progress Progress { get; set; }
        public string TotalDuration => CalculateCourseDuration();

        // Navigation properties
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public Instructor Instructor { get; set; } = null!;

        public string CalculateCourseDuration()
        {
            if (!Lessons.Any()) return "0hrs 0min";

            var totalMinutes = Lessons.Sum(l => l.DurationInMinutes);
            var hours = totalMinutes / 60;
            var minutes = totalMinutes % 60;
            return $"{hours}hrs {minutes}min";
        }
    }
}
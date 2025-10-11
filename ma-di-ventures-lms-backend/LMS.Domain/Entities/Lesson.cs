using LMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public int CouseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content {  get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public int Order {  get; set; }
        public LessonType Type { get; set; }
        public Progress Progress { get; set; }

        // Navigation properties
        public Course Course { get; set; } = null!;
    }
}
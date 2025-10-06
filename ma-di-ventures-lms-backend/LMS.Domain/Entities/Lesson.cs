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
        public string Title { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public LessonType Type { get; private set; }
        public int Order {  get; set; }
    }
}
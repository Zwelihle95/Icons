using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Commands.AddCourse
{
    public class AddCourseResult
    {
        public int CourseId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
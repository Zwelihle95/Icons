using LMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.DTOs.Enrollment
{
    public class EnrolledCourseDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string EnrollmentStatus { get; set; } = string.Empty;
        public int ProgressPercentage { get; set; } = 0;
    }
}
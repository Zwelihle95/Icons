using LMS.Application.DTOs.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.DTOs.Student
{
    public class StudentDashboardDto
    {
        public int TotalEnrolledCourses { get; set; }
        public int CompletedCourses { get; set; }
        public int ActiveCourses { get; set; }
        public int CompletionPercentage { get; set; }
        public ICollection<EnrolledCourseDto> EnrolledCourses { get; set; } = new List<EnrolledCourseDto>();
    }
}
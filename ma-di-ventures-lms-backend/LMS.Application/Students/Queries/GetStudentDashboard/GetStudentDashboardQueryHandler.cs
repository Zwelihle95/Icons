using LMS.Application.DTOs.Enrollment;
using LMS.Application.DTOs.Student;
using LMS.Domain.Enums;
using LMS.Domain.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Students.Queries.GetStudentDashboard
{
    public class GetStudentDashboardQueryHandler : IRequestHandler<GetStudentDashboardQuery, StudentDashboardDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetStudentDashboardQueryHandler(
            IStudentRepository studentRepository, 
            ICourseRepository courseRepository, 
            IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<StudentDashboardDto> Handle(GetStudentDashboardQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.StudentId);

            if (student == null) throw new ArgumentNullException(nameof(student));

            var enrollments = await _enrollmentRepository.GetByStudentIdAsync(request.StudentId);

            var totalEnrolled = enrollments.Count();
            var completed = enrollments.Count(e => e.EnrollmentStatus == EnrollmentStatus.Completed);
            var active = enrollments.Count(e => e.EnrollmentStatus == EnrollmentStatus.Active);
            var completionPercentage = totalEnrolled > 0
            ? (int)completed / totalEnrolled * 100
            : 0;

            var enrolledCourses = new List<EnrolledCourseDto>();

            foreach (var enrollment in enrollments)
            {
                var course = await _courseRepository.GetByIdAsync(enrollment.CourseId);

                if (course == null) continue;

                enrolledCourses.Add(new EnrolledCourseDto
                {
                    CourseId = course.Id,
                    Title = course.Title,
                    EnrollmentStatus = enrollment.EnrollmentStatus.ToString(),
                    ProgressPercentage = enrollment.ProgressPercentage
                });
            }

            return new StudentDashboardDto
            {
                TotalEnrolledCourses = totalEnrolled,
                CompletedCourses = completed,
                ActiveCourses = active,
                CompletionPercentage = completionPercentage,
                EnrolledCourses = enrolledCourses
            };
        }
    }
}
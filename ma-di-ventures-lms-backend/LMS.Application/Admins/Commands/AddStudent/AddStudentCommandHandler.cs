using LMS.Domain.Entities;
using LMS.Domain.Enums;
using LMS.Domain.Repositories.Interfaces;
using LMS.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Commands.AddStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentResult>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public AddStudentCommandHandler(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository, 
            IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<AddStudentResult> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var password = new SecurePassword(request.Password);

            var student = new Student(
                request.FirstName,
                request.LastName,
                request.Company,
                email,
                password
            );

            await _studentRepository.AddStudentAsync(student);

            if (request.CourseIds.Any())
            {
                var enrollments = new List<Enrollment>();

                foreach (var courseId in request.CourseIds)
                {
                    var course = await _courseRepository.GetByIdAsync(courseId);

                    if (course == null)
                        continue;

                    var alreadyEnrolled = await _enrollmentRepository.IsStudentEnrolledAsync(student.Id, courseId);

                    if (alreadyEnrolled)
                        continue;

                    enrollments.Add(new Enrollment
                    {
                        StudentId = student.Id,
                        CourseId = courseId,
                        ProgressPercentage = 0,
                        EnrollmentStatus = EnrollmentStatus.Active
                    });
                }

                if (enrollments.Any())
                {
                    await _enrollmentRepository.AddRangeAsync(enrollments);
                }
            }
            return new AddStudentResult
            {
                StudentId = student.Id,
                Success = true,
                Message = "Student successfully added."
            };
        }
    }
}
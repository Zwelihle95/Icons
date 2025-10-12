using LMS.Application.Admins.Commands.AddCourse;
using LMS.Domain.Entities;
using LMS.Domain.Repositories.Interfaces;
using LMS.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Commands.CreateCourse
{
    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, AddCourseResult>
    {
        private readonly ICourseRepository _courseRepository;

        public AddCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<AddCourseResult> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                Title = request.Title,
                Description = request.Description,
                Level = request.Level,
                IsActive = false
            };

            await _courseRepository.AddCourseAsync(course);

            return new AddCourseResult
            {
                CourseId = course.Id,
                Success = true,
                Message = "Course added successfully."
            };
        }
    }
}
using LMS.Application.DTOs.Course;
using LMS.Application.Instructor.DTOs;
using LMS.Application.Students.DTOs;
using LMS.Domain.Entities;
using LMS.Domain.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly ICourseRepository _courseRepositoy;

        public GetAllCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepositoy = courseRepository;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepositoy.GetAllCoursesAsync();

            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Level = c.Level,
                IsActive = c.IsActive,
                Lessons = c.Lessons
            });
        }
    }
}
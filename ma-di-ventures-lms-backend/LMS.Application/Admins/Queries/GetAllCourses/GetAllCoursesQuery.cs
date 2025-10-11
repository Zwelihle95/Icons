using LMS.Application.DTOs.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Queries.GetAllCourses
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<CourseDto>>
    {
    }
}
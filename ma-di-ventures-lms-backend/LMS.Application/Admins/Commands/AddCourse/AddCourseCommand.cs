using LMS.Application.Admins.Commands.CreateCourse;
using LMS.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Commands.AddCourse
{
    public class AddCourseCommand : IRequest<AddCourseResult>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CourseLevel Level { get; set; }
    }
}
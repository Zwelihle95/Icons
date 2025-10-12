using LMS.Application.Admins.Commands.AddCourse;
using LMS.Application.Admins.Commands.CreateStudent;
using LMS.Application.Admins.Queries.GetAllCourses;
using LMS.Application.Admins.Queries.GetAllStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Presentation.Controllers.Courses
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var students = await _mediator.Send(new GetAllCoursesQuery());

            return Ok(students);
        }
    }
}
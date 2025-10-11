using LMS.Application.Admins.Commands.CreateStudent;
using LMS.Application.Admins.Queries.GetAllStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Presentation.Controllers.Students
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand request)
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
        public async Task<IActionResult> GetAllStudents([FromBody] string? company = null)
        {
            var query = new GetAllStudentsQuery { CompanyFilter = company };
            var students = await _mediator.Send(query);

            return Ok(students);
        }
    }
}

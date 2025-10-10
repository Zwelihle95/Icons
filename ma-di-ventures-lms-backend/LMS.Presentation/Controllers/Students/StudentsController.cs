using LMS.Application.Admins.Commands.CreateStudent;
using LMS.Application.Admins.Queries.GetAllStudents;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Presentation.Controllers.Students
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly CreateStudentCommandHandler _createStudentHandler;
        private readonly GetAllStudentsQueryHandler _getAllStudentsHandler;

        public StudentsController(
            CreateStudentCommandHandler createStudentHandler,
            GetAllStudentsQueryHandler getAllStudentsHandler)
        {
            _createStudentHandler = createStudentHandler;
            _getAllStudentsHandler = getAllStudentsHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            try
            {
                var result = await _createStudentHandler.HandleAsync(command);
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
            var students = await _getAllStudentsHandler.HandleAsync(query);

            return Ok(students);
        }
    }
}

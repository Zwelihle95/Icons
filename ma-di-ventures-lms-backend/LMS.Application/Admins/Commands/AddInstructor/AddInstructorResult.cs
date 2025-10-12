using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Commands.AddInstructor
{
    public class AddInstructorResult
    {
        public int InstructorId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
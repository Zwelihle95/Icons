using LMS.Domain.Entities;
using LMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admin.Commands.CreateStudent
{
    public class CreateStudentCommand
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        public SecurePassword Password { get; private set; } = null!;
        public string Company { get; private set; } = string.Empty;
        public List<CourseEnrollment> Enrollements { get; private set; } = new List<CourseEnrollment>();
    }
}
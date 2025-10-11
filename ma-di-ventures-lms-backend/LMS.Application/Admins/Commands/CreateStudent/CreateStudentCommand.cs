using LMS.Domain.Entities;
using LMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using LMS.Application.Admins.DTOs;

namespace LMS.Application.Admins.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<CreateStudentResult>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
    }
}
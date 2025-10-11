using LMS.Domain.Entities;
using LMS.Domain.Repositories.Interfaces;
using LMS.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Commands.CreateStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentResult>
    {
        private readonly IStudentRepository _studentRepository;

        public AddStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<AddStudentResult> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var password = new SecurePassword(request.Password);

            var student = new Student(
                request.FirstName,
                request.LastName,
                request.Company,
                email,
                password
            );

            await _studentRepository.AddStudentAsync(student);

            return new AddStudentResult
            {
                StudentId = student.Id,
                Success = true,
                Message = "Student successfully created."
            };
        }
    }
}
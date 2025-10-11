using LMS.Application.Admins.DTOs;
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
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentResult>
    {
        private readonly IAdminRepository _repository;

        public CreateStudentCommandHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateStudentResult> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
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

            await _repository.AddAsync(student);

            return new CreateStudentResult
            {
                StudentId = student.Id,
                Success = true,
                Message = "Student successfully created."
            };
        }
    }
}
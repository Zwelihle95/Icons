using LMS.Application.Admins.DTOs;
using LMS.Domain.Entities;
using LMS.Domain.Repositories.Interfaces;
using LMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Commands.CreateStudent
{
    public class CreateStudentCommandHandler
    {
        private readonly IAdminRepository _repository;

        public CreateStudentCommandHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateStudentResult> HandleAsync(CreateStudentCommand command)
        {
            try
            {
                // implement a repo to check email existance
                // implement email exist

                var email = new Email(command.Email);
                var password = new SecurePassword(command.Password);

                var student = new Student
                    (
                        command.FirstName,
                        command.LastName,
                        command.Company,
                        email,
                        password
                    );

                await _repository.CreateAsync(student);

                return new CreateStudentResult
                {
                    StudentId = student.Id,
                    Success = true,
                    Message = "Student successfully created."
                };
            }
            catch (Exception ex)
            {
                return new CreateStudentResult
                {
                    Success = true,
                    Message = "Student successfully created. " + ex.Message
                };
            }
        }
    }
}
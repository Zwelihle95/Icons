using LMS.Domain.Entities;
using LMS.Domain.Repositories.Interfaces;
using LMS.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Commands.AddInstructor
{
    public class AddInstructorCommandHandler : IRequestHandler<AddInstructorCommand, AddInstructorResult>
    {
        private readonly IInstructorRepository _instructorRepository;

        public AddInstructorCommandHandler(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<AddInstructorResult> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var password = new SecurePassword(request.Password);

            var instructor = new Instructor(
                request.FirstName,
                request.LastName,
                email,
                password,
                request.Bio,
                request.Specialization
            );

            await _instructorRepository.AddInstructorAsync(instructor);

            return new AddInstructorResult
            {
                InstructorId = instructor.Id,
                Success = true,
                Message = "Instructor successfully added."
            };
        }
    }
}
using LMS.Application.DTOs.Instructor;
using LMS.Domain.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Queries.GetAllInstructors
{
    public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, IEnumerable<InstructorDto>>
    {
        private readonly IInstructorRepository _instructorRepository;

        public GetAllInstructorsQueryHandler(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<InstructorDto>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
        {
            var instructors = await _instructorRepository.GetAllInstructorsAsync();

            return instructors.Select(i => new InstructorDto
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Bio = i.Bio,
                Specialization = i.Specialization,
                Email = i.Email.UserEmail
            });
        }
    }
}
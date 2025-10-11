using LMS.Application.Students.DTOs;
using LMS.Domain.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAllStudentsQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _adminRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(request.CompanyFilter))
            {
                students = students.Where(s => s.Company == request.CompanyFilter);
            }

            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Company = s.Company,
                Email = s.Email.UserEmail,
            });
        }
    }
}
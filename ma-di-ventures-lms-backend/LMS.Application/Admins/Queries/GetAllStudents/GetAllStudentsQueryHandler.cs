using LMS.Application.Students.DTOs;
using LMS.Domain.Entities;
using LMS.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler
    {
        private readonly IUserRepository _userRepository;

        public GetAllStudentsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<StudentDto>> HandleAsync(GetAllStudentsQuery query)
        {
            var students = await _userRepository.GetAllByRoleAsync<Student>();

            if (!string.IsNullOrEmpty(query.CompanyFilter))
            {
                students = students.Where(s => s.Company == query.CompanyFilter);
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
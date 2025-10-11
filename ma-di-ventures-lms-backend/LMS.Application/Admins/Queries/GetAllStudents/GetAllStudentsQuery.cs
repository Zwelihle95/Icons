using LMS.Application.Students.DTOs;
using LMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<StudentDto>>
    {
        public string? CompanyFilter { get; set; }
    }
}
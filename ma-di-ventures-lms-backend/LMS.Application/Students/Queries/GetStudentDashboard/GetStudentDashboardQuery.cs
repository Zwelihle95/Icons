using LMS.Application.DTOs.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Students.Queries.GetStudentDashboard
{
    public class GetStudentDashboardQuery : IRequest<StudentDashboardDto>
    {
        public int StudentId { get; set; }
    }
}
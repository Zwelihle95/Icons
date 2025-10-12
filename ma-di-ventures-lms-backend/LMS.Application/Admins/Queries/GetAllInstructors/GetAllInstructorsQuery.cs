using LMS.Application.DTOs.Instructor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admins.Queries.GetAllInstructors
{
    public class GetAllInstructorsQuery : IRequest<IEnumerable<InstructorDto>>
    {
    }
}
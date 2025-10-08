using LMS.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Admin.Commands.CreateStudent
{
    public class CreateStudentCommandHandler
    {
        private readonly IAdminRepository _repository;

        public CreateStudentCommandHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<>
    }
}
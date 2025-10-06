using LMS.Domain.Entities;
using LMS.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        public Task CreateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}

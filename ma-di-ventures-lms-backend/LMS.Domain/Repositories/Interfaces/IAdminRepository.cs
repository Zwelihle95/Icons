using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task CreateAsync(User user);
    }
}

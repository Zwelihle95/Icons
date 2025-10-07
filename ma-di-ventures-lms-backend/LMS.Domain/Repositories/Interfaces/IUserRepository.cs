using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
    }
}

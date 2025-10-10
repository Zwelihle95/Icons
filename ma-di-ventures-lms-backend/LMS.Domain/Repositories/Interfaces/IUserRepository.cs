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
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllByRoleAsync<T>() where T : User;
        Task AddAsync(User user);
        Task<bool> EmailExistsAsync(string email);
    }
}

using LMS.Domain.Entities;
using LMS.Domain.Repositories.Interfaces;
using LMS.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly LMSDbContext _context;

        public UserRepository(LMSDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllByRoleAsync<T>() where T : User
        {
            return await _context.Users.OfType<T>().ToListAsync();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

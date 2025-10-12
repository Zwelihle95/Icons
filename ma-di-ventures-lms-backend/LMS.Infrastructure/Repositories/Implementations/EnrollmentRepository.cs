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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly LMSDbContext _context;
        public EnrollmentRepository(LMSDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<Enrollment> enrollments)
        {
            await _context.Enrollments.AddRangeAsync(enrollments);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Course) // ← Eager load to avoid N+1 queries
                .Where(e => e.StudentId == id)
                .ToListAsync();
        }

        public async 
            Task<int> GetEnrollmentCountAsync(string? courseTitle = null)
        {
            var query = _context.Enrollments.AsQueryable();

            // Apply course title filter if provided
            if (!string.IsNullOrWhiteSpace(courseTitle))
            {
                query = query.Include(e => e.Course)
                             .Where(e => e.Course.Title.Contains(courseTitle));
            }

            return await query.CountAsync();
        }

        public async Task<bool> IsStudentEnrolledAsync(int studentId, int courseId)
        {
            return await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }
    }
}
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task AddRangeAsync(IEnumerable<Enrollment> enrollments);
        Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);
        Task<int> GetEnrollmentCountAsync(string? courseTitle = null);
        Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int id);
    }
}
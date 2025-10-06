using LMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        public SecurePassword Password { get; private set; } = null!;

        public void ChangePassword(SecurePassword newPassword)
        {
            // some code
        }
    }
}

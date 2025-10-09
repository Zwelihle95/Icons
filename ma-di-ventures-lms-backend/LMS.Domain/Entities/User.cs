using LMS.Domain.Enums;
using LMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Email Email { get; set; } = null!;
        public SecurePassword Password { get; set; } = null!;
        public Role Role { get; set; }

        protected User() { }

        public User(string firstName, string lastName, Email email, SecurePassword password)
        {
           FirstName = firstName;
           LastName = lastName;
           Email = email;
           Password = password;
        }

        public void ChangePassword(SecurePassword newPassword)
        {
            Password = newPassword;
        }
    }
}

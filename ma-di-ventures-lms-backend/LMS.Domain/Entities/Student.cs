using LMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Student
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        public SecurePassword SecurePassword { get; private set; } = null!;

        private Student() { }

        public Student(
            string firstName,
            string lastName,
            Email email,
            SecurePassword securePassword
            )
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName)); ;
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName)); ;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            SecurePassword = securePassword ?? throw new ArgumentNullException(nameof(securePassword));
        }

        public void ChangeEmail(Email newEmail)
            => Email = newEmail ?? throw new ArgumentNullException(nameof(newEmail));

        public void ChangePassword(SecurePassword newPassword)
            => SecurePassword = newPassword ?? throw new ArgumentNullException(nameof(newPassword));

        public bool VerifyPassword(string plainPassword)
            => SecurePassword.VerifyPassword(plainPassword);
    }
}

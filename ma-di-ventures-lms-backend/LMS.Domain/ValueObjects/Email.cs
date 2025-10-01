using LMS.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LMS.Domain.ValueObjects
{
    public class Email
    {
        private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public string UserEmail { get; private set; } = string.Empty;

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidEmailException("Email cannot be empty");

            if (!Regex.IsMatch(email, EmailPattern))
                throw new InvalidEmailException($"Invalid email format: {email}");

            UserEmail = email.ToLowerInvariant();
        }

        public override bool Equals(object? obj)
            => obj is Email other && UserEmail == other.UserEmail;

        public override int GetHashCode() => UserEmail.GetHashCode();

        public override string ToString() => UserEmail;
    }
}

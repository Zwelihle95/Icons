using LMS.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LMS.Domain.ValueObjects
{
    public class SecurePassword
    {
        private const string PasswordPattern = "@\"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\w\\s]).{8,}$\"";
        private readonly string hashedPassword = string.Empty;

        public string HashedPassword => hashedPassword;

        public SecurePassword(string hashedPassword)
        {
            this.hashedPassword = hashedPassword;
        }

        public static void ValidatePassword(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new InvalidPasswordException("Password cannot be empty");

            if (!Regex.IsMatch(plainPassword, PasswordPattern))
                throw new InvalidPasswordException("Password must be:\n-8 characters in length" +
                    "\n-Include symbols, numbers and letters (lower and upper case).");
        }

        public static SecurePassword CreatePasswordHashFromPlainPassword(string plainPassword)
        {
            ValidatePassword(plainPassword);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword, workFactor: 12);

            return new SecurePassword(hashedPassword);
        }

        /*
         * This method creates password from hashpassword not plain text
         * It is later to be used in OnModelCreating to convert password from object to string for storage.
         */
        public static SecurePassword CreatePasswordFromHash(string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(hashedPassword))
                throw new ArgumentException("Hashed password cannot be empty");

            return new SecurePassword(hashedPassword);
        }

        public bool VerifyPassword(string plainPassword)
            => BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }
}

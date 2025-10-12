using LMS.Domain.ValueObjects;
using LMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Instructor : User
    {
        public string Bio {  get; set; } = string.Empty;
        public string Specialization {  get; set; } = string.Empty;

        // Navigation property
        public ICollection<Course> Courses { get; private set; } = new List<Course>();

        private Instructor() { }

        public Instructor(string firstName, string lastName, Email email, SecurePassword password, string bio, string specialization) : base(firstName, lastName, email, password)
        {
            Bio = bio;
            Specialization = specialization;
            Role = Role.Instructor;
        }
    }
}
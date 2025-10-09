using LMS.Domain.ValueObjects;
using LMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Student : User
    {
        public string Company { get; set; } = string.Empty;
        public List<CourseEnrollment> Enrollements { get; set; } = new();

        private Student() { }

        public Student(string firstName, string lastName, string company, Email email, SecurePassword password) : base(firstName, lastName, email, password)
        {
            Company = company;
            Role = Role.Student;
        }
    }
}
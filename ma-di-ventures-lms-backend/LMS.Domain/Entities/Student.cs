using LMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Student : User
    {
        public string Company { get; private set; } = string.Empty;
        public List<CourseEnrollment> Enrollements { get; private set; } = new List<CourseEnrollment>();
    }
}
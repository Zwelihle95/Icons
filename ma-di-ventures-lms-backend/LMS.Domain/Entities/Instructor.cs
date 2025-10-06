using LMS.Domain.ValueObjects;
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
        public List<Course> Courses { get; private set; } = new List<Course>();
        public List<string> Companies { get; private set; } = new List<string>();
    }
}

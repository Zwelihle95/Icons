using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Exceptions
{
    public class InvalidIdNumberException : Exception
    {
        public InvalidIdNumberException(string message) : base(message) { }
    }
}

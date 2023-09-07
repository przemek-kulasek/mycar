using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mycar.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public static int StatusCode => 404;
        public string? Name { get; }
        public string? Value { get; }

        public NotFoundException(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public NotFoundException(string name, Guid value)
        {
            Name = name;
            Value = value.ToString();
        }
    }
}

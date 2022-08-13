using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timberman
{
    /// <summary>
    /// Custom exception used is setters when bad value is assigned 
    /// </summary>
    class BadValueException : Exception
    {
        public BadValueException()
        {
        }

        public BadValueException(string message)
            : base(message)
        {
        }

        public BadValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

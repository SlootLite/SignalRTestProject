using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Exceptions
{
    public class ValueNotFoundException : Exception
    {
        public ValueNotFoundException(string message) : base(message)
        {

        }
    }
}

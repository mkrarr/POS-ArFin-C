using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.BL
{
    public class NotImplementedExceptionDescendant : NotImplementedException
    {
        public NotImplementedExceptionDescendant()
        {

        }
        public NotImplementedExceptionDescendant(string message)
            : base(message)
        {

        }
        public NotImplementedExceptionDescendant(string message, Exception inner)
            : base(message, inner)
        {

        }
        protected NotImplementedExceptionDescendant(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}

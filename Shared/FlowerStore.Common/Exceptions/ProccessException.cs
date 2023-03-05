using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FlowerStore.Common.Exceptions
{
    public class ProcessException : Exception
    {
        public string? Code { get; }

        public ProcessException()
        {
        }

        public ProcessException(string? message) : base(message)
        {
        }

        public ProcessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProcessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ProcessException(string code, string message) : base(message)
        {
            Code = code;
        }

        public ProcessException(string code, string message, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }


        public static void ThrowIf(Func<bool> predicate, string message)
        {
            if (predicate.Invoke())
                throw new ProcessException(message);
        }
    }
}
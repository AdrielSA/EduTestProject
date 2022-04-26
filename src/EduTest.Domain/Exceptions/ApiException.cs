using System;

namespace EduTest.Domain.Exceptions
{
    public class ApiException : Exception
    {
        public object Errors { get; set; }

        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(object erros)
        {
            Errors = erros;
        }
    }
}

using System;

namespace Sane.Semantics
{
    public class CompilationException : Exception
    {
        private readonly Errors _errors;
        public Errors Errors => _errors;

        public CompilationException(Errors errors)
        {
            _errors = errors;
        }
    }
}
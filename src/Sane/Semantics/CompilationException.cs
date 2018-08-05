using System;

namespace Sane.Semantics
{
    public class CompilationException : Exception
    {
        public Errors Errors { get; }

        public CompilationException(Errors errors) : base(errors.GetErrorsString())
        {
            Errors = errors;
        }
    }
}
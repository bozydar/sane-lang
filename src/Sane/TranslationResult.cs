namespace Sane
{
    public class TranslationResult
    {
        public string Output
        {
            get;
            protected set;
        }
        
        public string Errors
        {
            get;
            protected set;
        }
        
        public TranslationResult(string output, string errors)
        {
            Output = output;
            Errors = errors;
        }
    }
}
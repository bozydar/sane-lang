using System;
using System.IO;

namespace Sane.Cli
{
    public class Output
    {
        private readonly TranslationResult _translationResult;
        private readonly string _filePath;

        public Output(TranslationResult translationResult, string filePath)
        {
            _translationResult = translationResult;
            _filePath = filePath;
        }

        public void Proceed()
        {
            Console.Error.Write(_translationResult.Errors);

            if (string.IsNullOrEmpty(_filePath))
            {
                Console.Out.Write(_translationResult.Output);
            }
            else
            {
                using (var stream = new StreamWriter(_filePath, false))
                {
                    stream.Write(_translationResult.Output);
                }
            }
        }
    }
}
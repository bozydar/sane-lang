using System.IO;
using Microsoft.Extensions.CommandLineUtils;

namespace Sane.Cli
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "Sane",
                Description = "Sane Programing Language"
            };            
            app.HelpOption("-h|--help");
            var fileInArgument = app.Argument("file", "sn file to compile");
            var outputOption = app.Option("-o|--output<outputfile>",
                "Output compiled JS to",
                CommandOptionType.SingleValue);
            
            app.OnExecute(() =>
            {
                var inputFilePath = fileInArgument.Value;
                var outputFilePath = outputOption.HasValue() ? outputOption.Value() : inputFilePath + ".js";
                var compiler = new Compiler();
                if (string.IsNullOrEmpty(inputFilePath))
                {
                    app.Error.WriteLine("No input file provided. sanec --help to find out more");
                    return 1;
                }
                var input = File.ReadAllText(inputFilePath);
                var translationResult = compiler.Translate(input);
                var output = new Output(translationResult, outputFilePath);
                output.Proceed();
                return 0;
            });

            app.Execute(args);
        }
    }
}
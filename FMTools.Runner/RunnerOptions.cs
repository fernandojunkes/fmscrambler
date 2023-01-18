
using System.ComponentModel.Design;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace FMTools.Runner
{
    internal class RunnerOptions
    {
        [Option('o', "options", Required = true, HelpText = "Input option file to read.")]
        public string OptionFile { get; set; }

        [HelpKeyword]
        public string GetUsage()
        {
            var usage = new StringBuilder();
            usage.AppendLine("Quickstart Application 1.0");
            usage.AppendLine("Read user manual for usage instructions...");
            return usage.ToString();
        }
    }
}

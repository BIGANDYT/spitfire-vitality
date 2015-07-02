namespace Spitfire.SIMExtensions.Console
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using SIM.Pipelines;

    public class ConsoleController : IPipelineController
    {
        public double Maximum { get; set; }

        public Pipeline Pipeline { get; set; }

        public void Start(string replaceHere, List<Step> steps)
        {
            System.Console.WriteLine("SIM: Operation Started : " + replaceHere);
        }

        public void IncrementProgress(long progress)
        {
        }

        public void Finish(string message, bool closeInterface)
        {
            System.Console.WriteLine("SIM:  Operation Finished : " + message);
        }

        public void ProcessorCrashed(string error)
        {
            System.Console.WriteLine("SIM:  Processor Crashed : " + error);
        }

        public void ProcessorDone(string title)
        {
            System.Console.WriteLine("SIM:  Processor Done : " + title);
        }

        public void ProcessorSkipped(string processorName)
        {
            System.Console.WriteLine("SIM: Processor Skipped : " + processorName);
        }

        public void ProcessorStarted(string title)
        {
            System.Console.WriteLine("SIM:  Processor Started : " + title);
        }

        public void Execute(string path, string args)
        {
            Process.Start(path, args);
        }

        public void IncrementProgress()
        {
        }

        public void Pause()
        {
            System.Console.WriteLine("Pause...");
        }

        public string Ask(string title, string defaultValue)
        {
            System.Console.WriteLine("Asking: " + title);
            System.Console.WriteLine("Automatically returning defaultValue: " + defaultValue);
            return defaultValue;
        }

        public bool Confirm(string message)
        {
            System.Console.WriteLine("Confirming automatically: " + message);
            return true;
        }

        public void Resume()
        {
            System.Console.WriteLine("Resume...");
        }

        public string Select(
            string message,
            IEnumerable<string> options,
            bool allowMultipleSelection,
            string defaultValue)
        {
            System.Console.WriteLine("Select...");
            System.Console.WriteLine("Message: " + message);
            System.Console.WriteLine("Options: " + string.Join(",", options));
            System.Console.WriteLine("AllowMultipleSelection: " + (allowMultipleSelection ? "yes" : "no"));

            if (!string.IsNullOrEmpty(defaultValue))
            {
                System.Console.WriteLine("Returning supplied DefaultValue: " + defaultValue);
                return defaultValue;
            }

            var myOptions = options.Where(x => x != "App Center Sync").ToList();

            if (allowMultipleSelection)
            {
                System.Console.WriteLine("Returning all options");
                return string.Join(",", myOptions);
            }

            var returnValue = myOptions.FirstOrDefault();
            System.Console.WriteLine("Returning first option: " + returnValue);
            return returnValue;
        }
    }
}
namespace Spitfire.SIMExtensions.Console
{
    using System.Collections.Generic;

    public class ExportArgs : BaseArgsProcessor
    {
        public string InstanceName
        {
            get { return this.GetArg("InstanceName"); }
        }

        public string ExportFilePath
        {
            get { return this.GetArg("ExportFilePath"); }
        }

        public string IgnoreFiles
        {
            get { return this.GetArg("IgnoreFiles"); }
        }

        public ExportArgs(IEnumerable<string> args) : base(args)
        {
        }
    }
}
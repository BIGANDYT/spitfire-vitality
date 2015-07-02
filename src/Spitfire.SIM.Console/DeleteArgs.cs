namespace Spitfire.SIMExtensions.Console
{
    using System.Collections.Generic;

    public class DeleteArgs : BaseArgsProcessor
    {
        public string InstanceName
        {
            get { return this.GetArg("InstanceName"); }
        }

        public string InstanceDirectory
        {
            get { return this.GetArg("InstanceDirectory"); }
        }

        public string ConnectionString
        {
            get { return this.GetArg("ConnectionString"); }
        }

        public DeleteArgs(IEnumerable<string> args)
            : base(args)
        {
        }
    }
}

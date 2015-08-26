namespace Spitfire.SIMExtensions.Console
{
    using System.Collections.Generic;

    public class InstallArgs : BaseArgsProcessor
    {
        public string InstanceName
        {
            get { return this.GetArg("InstanceName"); }
        }

        public string InstanceDirectory
        {
            get { return this.GetArg("InstanceDirectory"); }
        }

        public string RepoDirectory
        {
            get { return this.GetArg("RepoDirectory"); }
        }

        public string RepoFile
        {
            get { return this.GetArg("RepoFile"); }
        }

        public string ConnectionString
        {
            get { return this.GetArg("ConnectionString"); }
        }

        public string AppPoolIdentity
        {
            get { return this.GetArg("AppPoolIdentity"); }
        }

        public string LicencePath
        {
            get { return this.GetArg("LicencePath"); }
        }

        public string Modules
        {
            get { return this.GetArg("Modules"); }
        }

        public InstallArgs(IEnumerable<string> args) : base(args)
        {
        }
    }
}

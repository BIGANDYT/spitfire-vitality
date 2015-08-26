namespace Spitfire.SIMExtensions.Console
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class ImportArgs : BaseArgsProcessor
    {
        private Dictionary<string, int> _bindings;
        private SqlConnectionStringBuilder _connectionString;

        public string PathToExportedInstance
        {
            get { return this.GetArg("PathToExportedInstance"); }
        }

        public string SiteName
        {
            get
            {
                return this.GetArg("SiteName");
            }
        }

        public string TemporaryPathToUnpack
        {
            get
            {
                return this.GetArg("TemporaryPathToUnpack");
            }
        }

        public string RootPath
        {
            get
            {
                return this.GetArg("RootPath");
            }
        }

        public SqlConnectionStringBuilder ConnectionString
        {
            get
            {
                return this._connectionString
                       ?? (this._connectionString = new SqlConnectionStringBuilder(this.GetArg("ConnectionString")));
            }
        }

        public bool UpdateLicense
        {
            get
            {
                return this.GetBoolean(this.GetArg("UpdateLicense"));
            }
        }

        public string PathToLicenseFile
        {
            get { return this.GetArg("PathToLicenseFile"); }
        }

        public Dictionary<string, int> Bindings
        {
            get
            {
                if (_bindings == null)
                {
                    _bindings = new Dictionary<string, int>();
                    var bindings = this.GetArg("Bindings");
                    foreach (var binding in bindings.Split('|'))
                    {
                        var arr = binding.Trim().Split(':');
                        if (arr.Length != 2) continue;

                        int port;
                        if (!int.TryParse(arr[1], out port)) continue;

                        _bindings[arr[0]] = port;
                    }
                }

                return _bindings;
            }
        }

        public ImportArgs(IEnumerable<string> args)
            : base(args)
        {
        }
    }
}
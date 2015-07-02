namespace Spitfire.SIMExtensions.Console
{
    using System.Collections.Generic;
    using System.Linq;

    public class BaseArgsProcessor
    {
        private readonly IEnumerable<string> _args;

        public BaseArgsProcessor(IEnumerable<string> args )
        {
            this._args = args;
        }

        protected string GetArg(string key)
        {
            string arg = this._args.FirstOrDefault(x => x.ToLowerInvariant().StartsWith(key.ToLowerInvariant()));
            if (arg == null)
            {
                return string.Empty;
            }

            return arg.Substring(key.Length + 1);
        }
    }
}

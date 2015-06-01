namespace Spitfire.SIMExtensions.Delete
{
    using System;
    using Microsoft.Win32;
    using SIM.Base;
    using SIM.Pipelines.Delete;

    [UsedImplicitly]
    public class DeleteRegistryKey : DeleteProcessor
    {
        protected const string SitecoreNodePath = "SOFTWARE\\Wow6432Node\\Sitecore CMS";

        protected override void Process(DeleteArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            var localMachine = Registry.LocalMachine;
            Assert.IsNotNull(localMachine, "localMachine");

            var sitecoreKey = localMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Sitecore CMS", true);
            if (sitecoreKey == null)
            {
                return;
            }

            foreach (var subKeyName in sitecoreKey.GetSubKeyNames())
            {
                Assert.IsNotNull(subKeyName, "subKeyName");
                var subKey = sitecoreKey.OpenSubKey(subKeyName);

                if (subKey == null)
                {
                    continue;
                }

                var siteName = subKey.GetValue("IISSiteName") as string ?? string.Empty;
                var instanceDirectory = (subKey.GetValue("InstanceDirectory") as string ?? string.Empty).TrimEnd('\\');
                
                if (!siteName.Equals(args.InstanceName, StringComparison.OrdinalIgnoreCase))
                {
                    if (!instanceDirectory.Equals(args.Instance.RootPath.TrimEnd('\\'), StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                }

                Log.Info(string.Format("Deleting {0}\\{1} key from registry", "SOFTWARE\\Wow6432Node\\Sitecore CMS", subKeyName), this);
                sitecoreKey.DeleteSubKey(subKeyName);
                break;
            }
        }
    }
}
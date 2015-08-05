namespace Spitfire.SIMExtensions.Console
{
    using System;
    using System.Diagnostics;

    using SIM.Pipelines;

    public class ImportProcess
    {
        public bool Execute(ImportArgs args)
        {
            try
            {
                Console.WriteLine("SIM: Starting Import");

                Debug.Assert(args.PathToExportedInstance != null, "args.PathToExportedInstance != null");
                Debug.Assert(args.SiteName != null, "args.SiteName != null");
                Debug.Assert(args.TemporaryPathToUnpack != null, "args.TemporaryPathToUnpack != null");
                Debug.Assert(args.RootPath != null, "args.RootPath != null");
                Debug.Assert(args.ConnectionString != null, "args.ConnectionString != null");
                Debug.Assert(args.Bindings != null, "args.Bindings != null");

                if (args.UpdateLicense)
                {
                    Debug.Assert(args.PathToLicenseFile != null, "args.PathToLicenseFile != null");
                }

                var importArgs = new SIM.Pipelines.Import.ImportArgs(
                    args.PathToExportedInstance,
                    args.SiteName,
                    args.TemporaryPathToUnpack,
                    args.RootPath,
                    args.ConnectionString,
                    args.UpdateLicense,
                    args.PathToLicenseFile,
                    args.Bindings);

                IPipelineController controller = new ConsoleController();

                // Import the sucker
                PipelineManager.Initialize();
                PipelineManager.StartPipeline(
                    "import",
                    importArgs,
                    controller,
                    false);

                Console.WriteLine("SIM: Finished Import");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sitecore SIM import failed {0}", ex);
                return false;
            }
        }
    }
}
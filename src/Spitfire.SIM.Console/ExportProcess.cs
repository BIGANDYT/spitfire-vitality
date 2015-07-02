namespace Spitfire.SIMExtensions.Console
{
    using System;

    using SIM.Instances;
    using SIM.Pipelines;

    public class ExportProcess
    {
        public bool Execute(ExportArgs args)
        {
            try
            {
                Console.WriteLine("SIM: Starting Export");

                var instance = InstanceManager.GetInstance(args.InstanceName);
                if (instance == null)
                {
                    Console.WriteLine("SIM: Error! The instance with the name {0} does not exist", args.InstanceName);
                    return false;
                }

                var exportArgs = new SIM.Pipelines.Export.ExportArgs(
                    instance,
                    wipeSqlServerCredentials: false,
                    includeMongoDatabases: true,
                    includeTempFolderContents: false,
                    includeMediaCacheFolderContents: true,
                    excludeUploadFolderContents: true,
                    excludeLicenseFile: true,
                    excludeDiagnosticsFolderContents: true,
                    excludeLogsFolderContents: true,
                    excludePackagesFolderContents: true,
                    exportFilePath: args.ExportFilePath,
                    selectedDatabases: new[] { "core", "master", "web", "reporting" });

                IPipelineController controller = new ConsoleController();

                // Export the sucker
                PipelineManager.Initialize();
                PipelineManager.StartPipeline(
                    "export",
                    exportArgs,
                    controller,
                    false);

                Console.WriteLine("SIM: Finished Export");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sitecore SIM export failed {0}", ex);
                return false;
            }
        }
    }
}
﻿namespace Spitfire.SIMExtensions.Console
{
    using System;
    using System.Data.SqlClient;

    using SIM.Instances;
    using SIM.Pipelines;

    public class DeleteProcess
    {
        public bool Execute(DeleteArgs args)
        {
            try
            {
                System.Console.WriteLine("SIM: Starting Delete");

                InstanceManager.Initialize(args.InstanceDirectory);
                var instance = InstanceManager.GetInstance(args.InstanceName);


                if (instance == null)
                {
                    System.Console.WriteLine("SIM: Warning! Can't detect installed instance {0}", args.InstanceName);
                    return true;
                }

                SIM.Pipelines.Delete.DeleteArgs deleteArgs = new SIM.Pipelines.Delete.DeleteArgs(instance, new SqlConnectionStringBuilder(args.ConnectionString));
                IPipelineController controller = new ConsoleController();

                PipelineManager.Initialize();

                PipelineManager.StartPipeline(
                    "delete",
                    deleteArgs,
                    controller,
                    false);

                System.Console.WriteLine("SIM: Finished Delete");

                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Sitecore SIM install failed", ex);
                return false;
            }
        }
    }
}

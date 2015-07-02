namespace Spitfire.SIMExtensions.Console
{
    using System.Collections.Generic;
    using System.Linq;

    using SIM.Base;
    using SIM.Pipelines;
    using SIM.Pipelines.Install;
    using SIM.Products;

    public class InstallActions : InstallProcessor
    {
        private readonly List<Product> done = new List<Product>();

        protected override bool IsRequireProcessing(SIM.Pipelines.Install.InstallArgs args)
        {
            if (!this.ProcessorDefinition.Param.EqualsIgnoreCase("archive", false))
                return true;
            if (args.Modules != null)
                return args.Modules.Any(m =>
                    {
                        if (m != null)
                            return m.IsArchive;
                        return false;
                    });
            return false;
        }

        protected override void Process(SIM.Pipelines.Install.InstallArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNull(args.Instance, "Instance", true);
            ConfigurationActions.ExecuteActions(args.Instance, args.Modules.ToArray(), this.done, this.ProcessorDefinition.Param, args.ConnectionString, this.Controller, null);
        }
    }
}
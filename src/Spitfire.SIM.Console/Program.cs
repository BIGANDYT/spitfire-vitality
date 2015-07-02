namespace Spitfire.SIMExtensions.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            switch (args[0])
            {
                case "install":
                    InstallArgs installArgs = new InstallArgs(args);
                    InstallProcess installProcess = new InstallProcess();
                    installProcess.Execute(installArgs);
                    break;
                case "delete":
                    DeleteArgs deleteArgs = new DeleteArgs(args);
                    DeleteProcess deleteProcess = new DeleteProcess();
                    deleteProcess.Execute(deleteArgs);
                    break;
                case "export":
                    var exportArgs = new ExportArgs(args);
                    var exportProcess = new ExportProcess();
                    exportProcess.Execute(exportArgs);
                    break;
            }
        }
    }
}
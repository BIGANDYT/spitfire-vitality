namespace Spitfire.SIMExtensions.Export
{
    using System.IO;
    using System.Linq;
    using Ionic.Zip;
    using Ionic.Zlib;
    using SIM.Base;
    using SIM.Pipelines.Export;

    public class ExportPostActions : ExportProcessor
    {
        protected override void Process(ExportArgs args)
        {
            var exportFile = args.ExportFile;
            CreateZip(args.Folder, exportFile);
            Directory.Delete(args.Folder, true);
        }

        private void CreateZip(string path, string zipFileName, string ignore = null)
        {
            ZipFile zipFile = new ZipFile
                                  {
                                      CompressionLevel = CompressionLevel.BestCompression,
                                      UseZip64WhenSaving = Zip64Option.AsNecessary
                                  };

            if (ignore == null)
            {
                zipFile.AddDirectory(path);
            }
            else
            {
                Assert.IsTrue(
                    !ignore.Contains('\\') && !ignore.Contains('/'),
                    "Multi-level ignore is not supported for archiving",
                    true);

                foreach (string str in Directory.GetDirectories(path))
                {
                    string name = new DirectoryInfo(str).Name;

                    if (!name.EqualsIgnoreCase(ignore, false))
                    {
                        zipFile.AddDirectory(str, name);
                    }
                }

                foreach (string fileName in Directory.GetFiles(path))
                {
                    zipFile.AddFile(fileName, "/");
                }
            }

            zipFile.Save(zipFileName);
        }
    }
}
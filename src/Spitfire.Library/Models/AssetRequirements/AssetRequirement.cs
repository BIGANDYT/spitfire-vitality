namespace Spitfire.Library.Models.AssetRequirements
{
    public class AssetRequirement
    {
        public AssetRequirement(AssetType type, string file, string inline = null, string addOnceToken = null)
        {
            Type = type;
            File = file;
            Inline = inline;
            AddOnceToken = addOnceToken;
        }

        public string File { get; set; }

        public string Inline { get; set; }

        public string AddOnceToken { get; set; }

        public AssetType Type { get; set; }

        public long GetDataLength()
        {
            var total = 0L;

            if (File != null)
            {
                total += File.Length;
            }

            if (Inline != null)
            {
                total += Inline.Length;
            }

            if (AddOnceToken != null)
            {
                total += AddOnceToken.Length;
            }

            return total;
        }
    }
}
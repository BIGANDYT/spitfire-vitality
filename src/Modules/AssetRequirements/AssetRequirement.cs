namespace Spitfire.Modules.AssetRequirements
{
    public class AssetRequirement
    {
        public AssetRequirement(AssetType type, string file, string inline = null, string addOnceToken = null)
        {
            this.Type = type;
            this.File = file;
            this.Inline = inline;
            this.AddOnceToken = addOnceToken;
        }

        public string File { get; set; }

        public string Inline { get; set; }

        public string AddOnceToken { get; set; }

        public AssetType Type { get; set; }

        public long GetDataLength()
        {
            var total = 0L;

            if (this.File != null)
            {
                total += this.File.Length;
            }

            if (this.Inline != null)
            {
                total += this.Inline.Length;
            }

            if (this.AddOnceToken != null)
            {
                total += this.AddOnceToken.Length;
            }

            return total;
        }
    }
}
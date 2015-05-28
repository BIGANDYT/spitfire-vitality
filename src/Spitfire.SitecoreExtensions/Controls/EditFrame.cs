namespace Spitfire.SitecoreExtensions.Controls
{
    using System;
    using System.IO;
    using System.Web.UI;

    using Sitecore.Web.UI.WebControls;

    /// <summary>
    /// Edit frame class. 
    /// </summary>
    /// <remarks>
    /// This class is required because MVC doesn't support sc:EditFrame
    /// </remarks>
    public class EditFrameRendering : IDisposable
    {
        /// <summary>
        /// The edit frame
        /// </summary>
        private readonly EditFrame editFrame;

        /// <summary>
        /// The html writer
        /// </summary>
        private readonly HtmlTextWriter htmlWriter;

        /// <summary>
        /// Renders the first part of the frame
        /// </summary>
        /// <param name="writer">The textwriter</param>
        /// <param name="dataSource">The datasource to use</param>
        /// <param name="buttons">The buttons to use</param>
        public EditFrameRendering(TextWriter writer, string dataSource, string buttons)
        {
            this.htmlWriter = new HtmlTextWriter(writer);
            this.editFrame = new EditFrame { DataSource = dataSource, Buttons = buttons };
            this.editFrame.RenderFirstPart(this.htmlWriter);
        }

        /// <summary>
        /// Render the last part of the editframe
        /// </summary>
        public void Dispose()
        {
            this.editFrame.RenderLastPart(this.htmlWriter);
            this.htmlWriter.Dispose();
        }
    }
}
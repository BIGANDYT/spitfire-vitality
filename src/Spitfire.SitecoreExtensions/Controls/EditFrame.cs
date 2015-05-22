namespace Spitfire.Framework.Controls
{
    using Sitecore.Web.UI.WebControls;
    using System.Web.UI;
    using System.IO;
    using System;

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
        private readonly EditFrame _editFrame;

        /// <summary>
        /// The html writer
        /// </summary>
        private readonly HtmlTextWriter _htmlWriter;

        /// <summary>
        /// Renders the first part of the frame
        /// </summary>
        /// <param name="writer">The textwriter</param>
        /// <param name="dataSource">The datasource to use</param>
        /// <param name="buttons">The buttons to use</param>
        public EditFrameRendering(TextWriter writer, String dataSource, String buttons)
        {
            _htmlWriter = new HtmlTextWriter(writer);
            _editFrame = new EditFrame { DataSource = dataSource, Buttons = buttons };
            _editFrame.RenderFirstPart(_htmlWriter);
        }

        /// <summary>
        /// Render the last part of the editframe
        /// </summary>
        public void Dispose()
        {
            _editFrame.RenderLastPart(_htmlWriter);
            _htmlWriter.Dispose();
        }
    }
}

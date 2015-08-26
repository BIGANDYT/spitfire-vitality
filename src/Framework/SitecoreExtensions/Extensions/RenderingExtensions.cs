﻿using System;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.Xml;

namespace Spitfire.SitecoreExtensions.Extensions
{
    public static class RenderingExtensions
    {
        public static string ImageUrl(this Rendering rendering, string fieldName, MediaUrlOptions options = null)
        {
            if (rendering == null)
                throw new ArgumentNullException(nameof(rendering));

            // Check if this rendering parameter exists
            // Also crude check to guess if this is actually XML.
            var parameters = rendering.Parameters[fieldName];
            if (string.IsNullOrEmpty(parameters) || !parameters.StartsWith("<"))
                return string.Empty;

            // Try and parse the parameters into XML
            var xml = XmlUtil.LoadXml(parameters);
            if (xml == null)
                return string.Empty;

            // Check if xml contains mediaid attribute
            var imageId = XmlUtil.GetAttribute("mediaid", xml);
            if (string.IsNullOrEmpty(imageId))
                return string.Empty;

            // Check if mediaid exists in database
            var imageItem = Sitecore.Context.Database.GetItem(imageId);
            if (imageItem == null)
                return string.Empty;

            // If no explicit options supplied, work out width and height from xml parameters
            if (options == null)
            {
                options = MediaUrlOptions.Empty;
                int width, height;

                if (int.TryParse(XmlUtil.GetAttribute("width", xml), out width))
                    options.Width = width;

                if (int.TryParse(XmlUtil.GetAttribute("height", xml), out height))
                    options.Height = height;
            }

            // Return hash protected URL.
            return HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(imageItem, options));
        }
    }
}
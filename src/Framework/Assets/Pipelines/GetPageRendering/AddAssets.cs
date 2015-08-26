﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Pipelines.Response.GetPageRendering;
using Sitecore.Mvc.Presentation;
using Sitecore.Xml;
using Spitfire.Framework.Assets.Models;
using Spitfire.Framework.SitecoreExtensions.Extensions;

namespace Spitfire.Framework.Assets.Pipelines.GetPageRendering
{
    /// <summary>
    /// Mvc.BuildPageDefinition pipeline processor to dynamically reference Cassette Bundles
    /// </summary>
    public class AddAssets : GetPageRenderingProcessor
    {
        private IList<AssetRequirement> _defaultAssets;

        private IList<AssetRequirement> DefaultAssets => this._defaultAssets ?? (this._defaultAssets = new List<AssetRequirement>());

        public void AddAsset(XmlNode node)
        {
            string assetTypeString = XmlUtil.GetAttribute("type", node, null);
            string assetFile = XmlUtil.GetAttribute("file", node, null);
            string scriptLocationString = XmlUtil.GetAttribute("location", node, null);

            if (string.IsNullOrWhiteSpace(assetTypeString) || string.IsNullOrWhiteSpace(assetFile))
            {
                Sitecore.Diagnostics.Log.Warn($"Invalid asset in GetPageRendering.AddAssets pipeline: {node.OuterXml}", this);
                return;
            }
            AssetType assetType;
            if (!Enum.TryParse(assetTypeString, true, out assetType))
            {
                Sitecore.Diagnostics.Log.Warn($"Invalid asset type in GetPageRendering.AddAssets pipeline: {node.OuterXml}", this);
                return;
            }
            ScriptLocation scriptLocation;
            if (scriptLocationString != null)
            {
                if (!Enum.TryParse(scriptLocationString, true, out scriptLocation))
                {
                    Sitecore.Diagnostics.Log.Warn($"Invalid script location in GetPageRendering.AddAssets pipeline: {node.OuterXml}", this);
                    return;
                }
                this.DefaultAssets.Add(new AssetRequirement(assetType, assetFile, scriptLocation));
            }
            this.DefaultAssets.Add(new AssetRequirement(assetType, assetFile));
        }

        public override void Process(GetPageRenderingArgs args)
        {
            this.AddDefaultAssetsFromConfiguration();

            this.AddPageAssets(PageContext.Current.Item);

            this.AddRenderingAssets(args.PageContext.PageDefinition.Renderings);
        }

        private void AddRenderingAssets(IEnumerable<Rendering> renderings)
        {
            foreach (var rendering in renderings)
            {
                if (Sitecore.Context.PageMode.IsNormal && rendering.Caching.Cacheable)
                    AssetRepository.Current.Add(rendering.RenderingItem.ID);
                var renderingItem = rendering.RenderingItem.InnerItem;

                var javaScriptAssets = renderingItem[Templates.RenderingAssets.Fields.ScriptFiles];
                foreach (var javaScriptAsset in javaScriptAssets.Split(';', ',', '\n'))
                    AssetRepository.Current.AddScript(javaScriptAsset, true);

                var javaScriptInline = renderingItem[Templates.RenderingAssets.Fields.InlineScript];
                if (!string.IsNullOrEmpty(javaScriptInline))
                    AssetRepository.Current.AddScript(javaScriptInline, renderingItem.ID.ToString(), ScriptLocation.Head, true);

                var cssAssets = renderingItem[Templates.RenderingAssets.Fields.StylingFiles];
                foreach (var cssAsset in cssAssets.Split(';', ',', '\n'))
                    AssetRepository.Current.AddStyling(cssAsset, true);

                var cssInline = renderingItem[Templates.RenderingAssets.Fields.InlineStyling];
                if (!string.IsNullOrEmpty(cssInline))
                    AssetRepository.Current.AddStyling(cssInline, renderingItem.ID.ToString(), true);
            }
        }

        private void AddPageAssets(Item item)
        {
            var styling = this.GetPageAssetValue(item, Templates.PageAssets.Fields.CssCode);
            if (!string.IsNullOrWhiteSpace(styling))
            {
                AssetRepository.Current.AddStyling(styling, styling.GetHashCode().ToString(), true);
            }
            var scriptBottom = this.GetPageAssetValue(item, Templates.PageAssets.Fields.JavascriptCodeBottom);
            if (!string.IsNullOrWhiteSpace(scriptBottom))
            {
                AssetRepository.Current.AddScript(scriptBottom, scriptBottom.GetHashCode().ToString(), ScriptLocation.Body, true);
            }
            var scriptHead = this.GetPageAssetValue(item, Templates.PageAssets.Fields.JavascriptCodeTop);
            if (!string.IsNullOrWhiteSpace(scriptHead))
            {
                AssetRepository.Current.AddScript(scriptHead, scriptHead.GetHashCode().ToString(), ScriptLocation.Head, true);
            }
        }

        private string GetPageAssetValue(Item item, ID assetField)
        {
            if (item.IsDerived(Templates.PageAssets.ID))
            {
                var assetValue = item[assetField];
                if (!string.IsNullOrWhiteSpace(assetValue))
                {
                    return assetValue;
                }
            }

            return GetInheritedPageAssetValue(item, assetField);
        }

        private static string GetInheritedPageAssetValue(Item item, ID assetField)
        {
            var inheritedAssetItem = item.Axes.GetAncestors().FirstOrDefault(i => i.IsDerived(Templates.PageAssets.ID) && MainUtil.GetBool(item[Templates.PageAssets.Fields.InheritAssets], false) && string.IsNullOrWhiteSpace(item[assetField]));
            return inheritedAssetItem?[assetField];
        }


        private void AddDefaultAssetsFromConfiguration()
        {
            foreach (var asset in this.DefaultAssets)
                AssetRepository.Current.Add(asset, true);
        }
    }
}
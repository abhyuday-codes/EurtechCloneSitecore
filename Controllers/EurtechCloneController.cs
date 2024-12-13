using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EurtechClone.Models;
using Sitecore.Resources.Media;
using Sitecore.Links;
using Sitecore.Xml.Xsl;
using Sitecore.Shell.Applications.ContentEditor;

namespace EurtechClone.Controllers
{
    public class EurtechCloneController : Controller
    {
        public ActionResult Header()
        {
            var dataSourceId = RenderingContext.CurrentOrNull?.Rendering.DataSource;
            if (dataSourceId == null)
            {
                Sitecore.Diagnostics.Log.Warn("RenderingContext or Rendering is null.", this);
                return View(new List<Item>()); // Return an empty list to avoid breaking the page
            }

            if (string.IsNullOrEmpty(dataSourceId))
            {
                Sitecore.Diagnostics.Log.Warn("DataSource is null or empty.", this);
                return View(new List<Item>()); // Return an empty list
            }

            // Fetch the DataSource item
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
            if (dataSource == null)
            {
                Sitecore.Diagnostics.Log.Warn($"DataSource item not found: {dataSourceId}", this);
                return View(new List<Item>()); // Return an empty list
            }

            var imageField = (Sitecore.Data.Fields.ImageField)dataSource.Fields["Logo"];
            string image = MediaManager.GetMediaUrl(imageField.MediaItem);
            string linkUrl = null;
            var linkField = (Sitecore.Data.Fields.LinkField)dataSource.Fields["Link"];

            if (linkField != null)
            {
                linkUrl = linkField.IsInternal ? LinkManager.GetItemUrl(linkField.TargetItem) : linkField.Url;
            }

            var model = new Models.Header
            {
                imageUrl = image,
                multilistItems = dataSource.Fields["PrimaryMenu"],
                Link = linkUrl
            };

            return View(model);
        }

        public ActionResult Footer()
        {
            var dataSourceId = RenderingContext.CurrentOrNull?.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
            
            var imageField = (Sitecore.Data.Fields.ImageField)dataSource.Fields["Logo"];
            string image = MediaManager.GetMediaUrl(imageField.MediaItem);


            var model = new Models.Footer
            {
                imageUrl = image,
                multilistLinkGroups = dataSource.Fields["FooterGroupLinkItems"],
                Links = dataSource.Fields["Links"],
                multilistRichTextGroups = dataSource.Fields["FooterRichTextItems"],
                CopyrightText = dataSource["CopyrightText"]
            };

            return View(model);
        }

        public ActionResult ITSolution()
        {
            var dataSourceId = RenderingContext.CurrentOrNull?.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            var imageField = (Sitecore.Data.Fields.ImageField)dataSource.Fields["BackgroundImage"];
            string image = MediaManager.GetMediaUrl(imageField.MediaItem);

            string link = null;
            var linkField = (Sitecore.Data.Fields.LinkField)dataSource.Fields["Link"];
            string Videolink = null;
            var VideolinkField = (Sitecore.Data.Fields.LinkField)dataSource.Fields["VideoLink"];
            string Medialink = null;
            var MedialinkField = (Sitecore.Data.Fields.LinkField)dataSource.Fields["MediaLink"];

            if (linkField != null)
            {
                link = linkField.IsInternal ? LinkManager.GetItemUrl(linkField.TargetItem) : linkField.Url;
            }
            if (VideolinkField != null)
            {
                Videolink = VideolinkField.IsInternal ? LinkManager.GetItemUrl(VideolinkField.TargetItem) : VideolinkField.Url;
            }
            if (MedialinkField != null)
            {
                Medialink = MedialinkField.IsInternal ? LinkManager.GetItemUrl(MedialinkField.TargetItem) : MedialinkField.Url;
            }

            var model = new Models.ITSolution
            {
                imageUrl = image,
                Text = dataSource["Text"],
                Heading = dataSource["Heading"],
                SubText = dataSource["SubText"],
                linkUrl = link,
                VideolinkUrl = Videolink,
                MedialinkUrl = Medialink
            };

            return View(model);
        }

        public ActionResult Services()
        {
            var dataSourceId = RenderingContext.CurrentOrNull?.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            string link = null;
            var linkField = (Sitecore.Data.Fields.LinkField)dataSource.Fields["Link"];

            if (linkField != null)
            {
                link = linkField.IsInternal ? LinkManager.GetItemUrl(linkField.TargetItem) : linkField.Url;
            }

            var model = new Models.Services
            {
                Link = link,
                Heading = dataSource["Heading"],
                Text = dataSource["Text"],
                ServiceComponents = dataSource.Fields["PrimaryItems"]
            };

            return View(model);
        }

        public ActionResult Testimonials()
        {
            var Model = new Models.Testimonials
            {

                Item = RenderingContext.Current?.Rendering.Item
            };

            return View("/Views/EurtechClone/Testimonials.cshtml", Model);
        }
    }
}
using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EurtechClone.Models
{
    public class ITSolution
    {
        public string imageUrl { get; set; }
        public string linkUrl { get; set; }
        public string VideolinkUrl { get; set; }
        public string MedialinkUrl { get; set; }

        public string Text { get; set; }
        public string Heading { get; set; }

        public string SubText { get; set; }
    }
}
using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EurtechClone.Models
{
    public class Footer
    {
        public string imageUrl { get; set; }
        public MultilistField Links { get; set; }
        public MultilistField multilistLinkGroups { get; set; }
        public MultilistField multilistRichTextGroups { get; set; }

        public string CopyrightText { get; set; }
    }
}
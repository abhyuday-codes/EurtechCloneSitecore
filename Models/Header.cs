using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EurtechClone.Models
{
    public class Header
    {
        public string imageUrl { get; set; }
        public string Link { get; set; }
        public MultilistField multilistItems { get; set; }
    }
}
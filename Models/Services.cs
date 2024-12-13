using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EurtechClone.Models
{
    public class Services
    {
        public string Text { get; set; }
        public string Heading { get; set; }
        public string Link { get; set; }

        public MultilistField ServiceComponents { get; set; }
    }
}
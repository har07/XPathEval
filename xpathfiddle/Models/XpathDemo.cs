using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace xpathfiddle.Models
{
    public class XpathDemo
    {
        public string Id { get; set; }
        public int Revision { get; set; }
        public string Xml { get; set; }
        public string Xpath { get; set; }
        public XpathResult Result { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using XPathEval.Processors;

namespace XPathEval.Models
{
    public class XPathDemo
    {
        public string Id { get; set; }
        public int Revision { get; set; }
        public XPathEngine Engine { get; set; }
        public string Xml { get; set; }
        public string XPath { get; set; }
        public XPathResult Result { get; set; }
    }
}
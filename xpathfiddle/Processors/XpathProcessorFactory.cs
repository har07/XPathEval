using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XPathEval.Processors
{
    public static class XPathProcessorFactory
    {
        public static IXPathProcessor Get(XPathEngine engine)
        {
            IXPathProcessor processor = new SaxonProcessor();
            switch (engine)
            {
                case XPathEngine.xpath3:
                    break;
                case XPathEngine.xpath1:
                    processor = new DotNetProcessor();
                    break;
                case XPathEngine.xquery3:
                    processor = new SaxonXQueryProcessor();
                    break;
                default:
                    break;
            }
            return processor;
        }
    }

    public enum XPathEngine
    {
        xpath3,
        xpath1,
        xquery3
    }
}
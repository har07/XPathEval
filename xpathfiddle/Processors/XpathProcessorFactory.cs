using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xpathfiddle.Processors
{
    public static class XpathProcessorFactory
    {
        public static IXpathProcessor Get(XpathEngine engine)
        {
            IXpathProcessor processor = new SaxonProcessor();
            switch (engine)
            {
                case XpathEngine.xpath3:
                    break;
                case XpathEngine.xpath1:
                    processor = new DotNetProcessor();
                    break;
                default:
                    break;
            }
            return processor;
        }
    }

    public enum XpathEngine
    {
        xpath3,
        xpath1
    }
}
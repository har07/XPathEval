using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPathEval.Processors
{
    public interface IXPathProcessor
    {
        string Process(string xml, string xpath);
    }
}

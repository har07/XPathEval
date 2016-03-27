using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpathfiddle.Processors
{
    interface IXpathProcessor
    {
        string Process(string xml, string xpath);
    }
}

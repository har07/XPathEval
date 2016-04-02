using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace xpathfiddle.Processors
{
    public class DotNetProcessor : IXpathProcessor
    {
        public string Process(string xml, string xpath)
        {
            var doc = XDocument.Parse(xml);
            var value = doc.XPathEvaluate(xpath);
            var result = "";
            if(value as IEnumerable == null || value is string)
            {
                result += value.ToString();
            }
            else
            {
                var values =
                    (value as IEnumerable).Cast<object>()
                                          .Select(o =>
                                          {
                                              if (o as XElement != null)
                                              {
                                                  return ((XElement)o).ToString();
                                              }
                                              else if (o as XAttribute != null)
                                              {
                                                  return ((XAttribute)o).ToString();
                                              }
                                              else
                                              {
                                                  return o.ToString();
                                              }
                                          });
                result += string.Join(Environment.NewLine, values);
            }
            return result;
        }
    }
}
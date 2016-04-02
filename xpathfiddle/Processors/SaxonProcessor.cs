using Saxon.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace xpathfiddle.Processors
{
    public class SaxonProcessor : IXpathProcessor
    {
        Processor _processor;
        XPathCompiler _compiler;
        DocumentBuilder _builder;

        public SaxonProcessor()
        {
            _processor = new Processor();
            _compiler = _processor.NewXPathCompiler();
            _builder = _processor.NewDocumentBuilder();
        }
        public string Process(string xml, string xpath)
        {
            var executable = _compiler.Compile(xpath);
            var evaluator = executable.Load();

            //set default context node:
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var root = _builder.Build(doc.DocumentElement);
            evaluator.ContextItem = root;
            
            var value = evaluator.Evaluate();
            var result = String.Join(Environment.NewLine, 
                                     value.Cast<XdmItem>()
                                          .Select(o => o.ToString())
                                     );
            return result;
        }
    }
}
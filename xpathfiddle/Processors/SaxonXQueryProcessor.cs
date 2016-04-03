using Saxon.Api;
using System;
using System.Linq;
using System.Xml;

namespace xpathfiddle.Processors
{
    public class SaxonXQueryProcessor : IXpathProcessor
    {
        Processor _processor;
        XQueryCompiler _compiler;
        DocumentBuilder _builder;

        public SaxonXQueryProcessor()
        {
            _processor = new Processor();
            _compiler = _processor.NewXQueryCompiler();
            _builder = _processor.NewDocumentBuilder();
        }
        public string Process(string xml, string xquery)
        {
            var executable = _compiler.Compile(xquery);
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
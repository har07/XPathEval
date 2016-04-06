using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using XPathEval.Models;
using XPathEval.Processors;

namespace XPathEval.Controllers
{
    public class XPathController : Controller
    {
        // GET: XPath
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ExecuteXPath(XPathDemo demo)
        {
            string result = "", error = "";
            IXPathProcessor processor = XPathProcessorFactory.Get(demo.Engine);
            try
            {
                result = processor.Process(demo.Xml, demo.XPath);
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return Json(new { data = result, error });
        }

        [HttpPost]
        public JsonResult FormatXml(XPathDemo demo)
        {
            string result = "", error = "";
            try
            {
                result = DotNetProcessor.Format(demo.Xml);
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return Json(new { data = result, error });
        }
    }
}
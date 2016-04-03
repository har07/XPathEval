using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using xpathfiddle.Models;
using xpathfiddle.Processors;

namespace xpathfiddle.Controllers
{
    public class XPathController : Controller
    {
        // GET: XPath
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ExecuteXpath(XpathDemo demo)
        {
            string result = "", error = "";
            IXpathProcessor processor = XpathProcessorFactory.Get(demo.Engine);
            try
            {
                result = processor.Process(demo.Xml, demo.Xpath);
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return Json(new { data = result, error });
        }

        [HttpPost]
        public JsonResult FormatXml(XpathDemo demo)
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
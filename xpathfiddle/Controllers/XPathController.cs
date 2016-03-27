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
        //public JsonResult ExecuteXpath(string jsonDemo)
        {
            //var serializer = new JavaScriptSerializer();
            //var demo = serializer.Deserialize<XpathDemo>(jsonDemo);
            string result = "", error = "";
            var processor = new Xpath3Processor();
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
    }
}
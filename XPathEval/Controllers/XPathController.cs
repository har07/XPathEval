using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using XPathEval.Models;
using XPathEval.Processors;
using XPathEval.Utils;

namespace XPathEval.Controllers
{
    public class XPathController : Controller
    {
        // GET: XPath
        public ActionResult Index(string id, int? revision)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var mongoModel = DataRepository.GetDemo(id, revision ?? 0);
                var model = mongoModel.Result.ToModel();
                return View(model);
            }
            return View(new XPathDemo());
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

        [HttpPost]
        public JsonResult SaveDemo(XPathDemo demo)
        {
            string error = "";
            XPathDemoMongo data = new XPathDemoMongo();
            var isSuccess = true;
            try
            {
                var mongoModel = new XPathDemoMongo();
                mongoModel.LoadFromModel(demo);
                data = DataRepository.CreateDemo(mongoModel);
            }
            catch (Exception e)
            {
                isSuccess = false;
                error = e.Message;
                return Json(new { isSuccess = isSuccess, error, data = data.Id });
            }
            return Json(new { isSuccess = isSuccess, error, data = UrlUtils.GetRedirectUrl(data, Request.RequestContext)});
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPathEval.Models;
using XPathEval.Processors;
using System.Linq;

namespace XPathEval.Tests.Models
{
    [TestClass]
    public class XPathDemoTest
    {
        [TestMethod]
        public void TestModelToMongo()
        {
            var models = new XPathDemo[]
            {
                new XPathDemo
                {
                    Id = "Random123",
                    Revision = 1,
                    Engine = XPathEngine.xpath3,
                    Xml = "<root/>",
                    XPath = "/*/self::*",
                    Result = new XPathResult { Data = "<root/>" }
                },
                new XPathDemo()
            };
            var isAllMatch = models.Select(model =>
            {
                var mongoModel = new XPathDemoMongo();
                mongoModel.LoadFromModel(model);
                
                var isMatch = (
                    mongoModel.Id == model.Id &&
                    mongoModel.Revision == model.Revision &&
                    (XPathEngine)Enum.ToObject(typeof(XPathEngine), mongoModel.Engine) == model.Engine &&
                    mongoModel.Xml == model.Xml &&
                    mongoModel.XPath == model.XPath &&
                    mongoModel.Result == model.Result.Data
                );
                return isMatch;
            }).All(o => o);

            Assert.IsTrue(isAllMatch);
        }
    }
}

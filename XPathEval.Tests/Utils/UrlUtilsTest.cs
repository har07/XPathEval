using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using XPathEval.Utils;
using System.Threading;

namespace XPathEval.Tests.Utils
{
    [TestClass]
    public class UrlUtilsTest
    {
        [TestMethod]
        public void TestRandomUrlGenerator()
        {
            var numberOfTest = 10;  //max ever run: 10000
            var countDistinct = Enumerable.Range(1, numberOfTest)
                                          .Select(o =>
                                          {
                                              Thread.Sleep(100);
                                              return UrlUtils.GetUrl();
                                          })
                                          .Distinct()
                                          .Count();
            Assert.AreEqual(numberOfTest, countDistinct);
        }
    }
}

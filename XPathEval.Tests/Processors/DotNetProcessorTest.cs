using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPathEval.Processors;

namespace XPathEval.Tests.Processors
{
    [TestClass]
    public class DotNetProcessorTest
    {
        [TestMethod]
        public void TestReturnElement()
        {
            //Arrange
            IXPathProcessor processor = XPathProcessorFactory.Get(XPathEngine.xpath1);

            //Act
            var result = processor.Process(DataProvider.GetInventorySample(), "//book[@id='myfave']/author");

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestReturnMixed()
        {
            //Arrange
            IXPathProcessor processor = XPathProcessorFactory.Get(XPathEngine.xpath1);
            /*
            * Test mixed of element, attribute & text node
            */
            var query = "//book[@id='myfave']/author/first-name";
            query += " | //book[@id='myfave']/@id";
            query += " | //book[@id='myfave']/author/last-name/text()";

            //Act
            var result = processor.Process(DataProvider.GetInventorySample(), query);

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestReturnNumber()
        {
            //Arrange
            IXPathProcessor processor = XPathProcessorFactory.Get(XPathEngine.xpath1);
            var query = "number(//book[1]/price)";

            //Act
            var result = processor.Process(DataProvider.GetInventorySample(), query);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("12", result);
        }

        [TestMethod]
        public void TestReturnBoolean()
        {
            //Arrange
            IXPathProcessor processor = XPathProcessorFactory.Get(XPathEngine.xpath1);
            var query = "//book[1]/price > 10";

            //Act
            var result = processor.Process(DataProvider.GetInventorySample(), query);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("True", result);
        }

        [TestMethod]
        public void TestReturnString()
        {
            //Arrange
            IXPathProcessor processor = XPathProcessorFactory.Get(XPathEngine.xpath1);
            var query = "concat(//book[1]/author/first-name, ' ', //book[1]/author/last-name)";

            //Act
            var result = processor.Process(DataProvider.GetInventorySample(), query);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Joe Bob", result);
        }
    }
}

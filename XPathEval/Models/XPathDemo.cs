using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using XPathEval.Processors;
using XPathEval.Utils;

namespace XPathEval.Models
{
    public class XPathDemo
    {
        public string Id { get; set; }
        public int Revision { get; set; }
        public XPathEngine Engine { get; set; } = XPathEngine.xpath3;
        public string Xml { get; set; }
        public string XPath { get; set; }
        public XPathResult Result { get; set; } = new XPathResult();
    }

    public class XPathDemoMongo
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Guid { get; set; }

        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("Revision")]
        public int Revision { get; set; }

        [BsonElement("Engine")]
        public int Engine { get; set; }

        [BsonElement("Xml")]
        public string Xml { get; set; }

        [BsonElement("XPath")]
        public string XPath { get; set; }

        [BsonElement("Result")]
        public string Result { get; set; }

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        public void LoadFromModel(XPathDemo model)
        {
            this.Id = model.Id;
            this.Revision = model.Revision;
            this.Engine = (int)model.Engine;
            this.Xml = model.Xml;
            this.XPath = model.XPath;
            this.Result = model.Result?.Data;
        }

        public XPathDemo ToModel()
        {
            return new XPathDemo
            {
                Id = this.Id,
                Revision = this.Revision,
                Engine = (XPathEngine)Enum.ToObject(typeof(XPathEngine), this.Engine),
                Xml = this.Xml,
                XPath = this.XPath,
                Result = new XPathResult { Data = this.Result }
            };
        }
    }
}
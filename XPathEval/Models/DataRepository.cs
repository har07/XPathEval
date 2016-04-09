using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using XPathEval.Utils;
using System.Configuration;

namespace XPathEval.Models
{
    public static class DataRepository
    {
        private static string connectionString = ConfigurationManager.AppSettings["MONGOLAB_URI"];
        private static string dbName = ConfigurationManager.AppSettings["MONGOLAB_DB"];
        private const string collectionName = "DemoList";

        // Gets all Demo items from the MongoDB server.        
        public static List<XPathDemoMongo> GetAllDemo()
        {
            try
            {
                var collection = GetDemoCollection();
                return collection.Find(new BsonDocument()).ToList();
            }
            catch (MongoConnectionException)
            {
                return new List<XPathDemoMongo>();
            }
        }

        public async static Task<XPathDemoMongo> GetDemo(string id, int revision)
        {
            var url = new MongoUrl(connectionString);
            var client = new MongoClient(url);
            var db = client.GetDatabase(dbName);
            var result = await db.GetCollection<XPathDemoMongo>(collectionName)
                                 .Find(o => o.Id == id)
                                 .FirstOrDefaultAsync()
                                 .ConfigureAwait(false);
            return result;
        }

        // Creates a Demo and inserts it into the collection in MongoDB.
        public static XPathDemoMongo CreateDemo(XPathDemoMongo demo)
        {
            var collection = GetDemoCollectionForEdit();
            if (!string.IsNullOrEmpty(demo.Id))
            {
                demo.Revision += 1;
            }
            else
            {
                demo.Id = UrlUtils.GetUrl();
            }
            collection.InsertOne(demo);
            return demo;
        }

        private static IMongoCollection<XPathDemoMongo> GetDemoCollection()
        {
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            var demoCollection = database.GetCollection<XPathDemoMongo>(collectionName);
            return demoCollection;
        }

        private static IMongoCollection<XPathDemoMongo> GetDemoCollectionForEdit()
        {
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            var demoCollection = database.GetCollection<XPathDemoMongo>(collectionName);
            return demoCollection;
        }
    }
}
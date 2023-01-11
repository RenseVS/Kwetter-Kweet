using System;
using Kweet_Service.Entities;
using MongoDB.Driver;

namespace Kweet_Service.Data
{
	public class DBContext : IDBContext
	{
        public DBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Tweet = database.GetCollection<Tweet>(configuration.GetValue<string>("DatabaseSettings:TweetCollectionName"));
        }

        public IMongoCollection<Tweet> Tweet { get; }
    }
}


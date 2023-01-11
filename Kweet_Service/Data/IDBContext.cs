using System;
using Kweet_Service.Entities;
using MongoDB.Driver;

namespace Kweet_Service.Data
{
	public interface IDBContext
	{
        IMongoCollection<Tweet> Tweet { get; }
    }
}


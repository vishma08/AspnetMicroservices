using Catalog.API.Entity;
using MongoDB.Driver;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
	public class CatalogContext : ICatalogContext
	{
		public CatalogContext(IConfiguration configuration)
		{
			var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
			var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

			Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

			CalalogContextSeed.SeedData(Products);
		}

		public IMongoCollection<Product> Products { get; }
	}
}

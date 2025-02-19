using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using LayeredArchitectureExample.Domain.Entities;


namespace LayeredArchitectureExample.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
        }

        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customer");
    }
}

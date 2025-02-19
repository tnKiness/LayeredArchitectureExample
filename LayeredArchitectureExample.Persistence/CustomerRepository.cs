using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using LayeredArchitectureExample.Domain.Entities;
using LayeredArchitectureExample.Domain.Interfaces;

namespace LayeredArchitectureExample.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepository(MongoDbContext context)
        {
            _customers = context.Customers;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customers.Find(c => true).ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            return await _customers.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _customers.InsertOneAsync(customer);
        }
    }
}

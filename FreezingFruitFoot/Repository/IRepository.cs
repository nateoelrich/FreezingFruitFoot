using FreezingFruitFoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreezingFruitFoot
{
    public interface IRepository
    {
        RepositoryResponse<List<Agent>> GetAgents();

        RepositoryResponse<Agent> GetAgent(int id);

        RepositoryResponse<Agent> InsertAgent(Agent a);

        RepositoryResponse<Agent> UpdateAgent(Agent a);

        RepositoryResponse<List<Customer>> GetCustomers();

        RepositoryResponse<List<Customer>> GetCustomers(int agentId);

        RepositoryResponse<Customer> InsertCustomer(Customer c);

        RepositoryResponse<Customer> UpdateCustomer(Customer c);

        RepositoryResponse<object> DeleteCustomer(int customerId);


    }
}

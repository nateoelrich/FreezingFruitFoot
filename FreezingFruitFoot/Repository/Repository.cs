using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FreezingFruitFoot.Models;
using Newtonsoft.Json;

namespace FreezingFruitFoot
{
    public class Repository: IRepository
    {

        private readonly string _custJSON = @"wwwroot\customers.json";
        private readonly string _agentJSON = @"wwwroot\agents.json";    

        public RepositoryResponse<List<Agent>> GetAgents()
        {
            try
            {
                var agents = JsonConvert.DeserializeObject<List<Agent>>(File.ReadAllText(this._agentJSON));

                return new RepositoryResponse<List<Agent>>() { IsSuccess = true, Content = agents };
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<List<Agent>>() { Message = ex.Message, IsSuccess = false };
            }
        }

        public RepositoryResponse<Agent> GetAgent(int id)
        {
            try
            {
                var agents = this.GetAgents();

                if (agents.IsSuccess)
                {
                    return new RepositoryResponse<Agent>() { IsSuccess = true, Content = agents.Content.Where(x => x._Id == id).FirstOrDefault() };
                }
                else
                {
                    return new RepositoryResponse<Agent>() { IsSuccess = false, Message = agents.Message };
                }                
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Agent>() { Message = ex.Message, IsSuccess = false };
            }
        }

        public RepositoryResponse<Agent> InsertAgent(Agent a)
        {
            try
            {
                var agents = this.GetAgents();

                if (agents.IsSuccess)
                {
                    agents.Content.Add(a);

                    var json = JsonConvert.SerializeObject(agents.Content.ToArray());

                    File.WriteAllText(this._agentJSON, json);

                    return new RepositoryResponse<Agent>() { IsSuccess = true, Content = a };
                }
                else
                {
                    return new RepositoryResponse<Agent>() { IsSuccess = false, Message = agents.Message };
                }
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Agent>() { Message = ex.Message, IsSuccess = false };
            }
        }

        public RepositoryResponse<Agent> UpdateAgent(Agent a)
        {
            try
            {
                var agents = this.GetAgents();

                if (agents.IsSuccess)
                {
                    var targetAgent = agents.Content.Where(x => x._Id == a._Id).FirstOrDefault();

                    if (null != targetAgent)
                    {
                        agents.Content.Remove(targetAgent);
                        targetAgent = a;
                        agents.Content.Add(targetAgent);

                        var json = JsonConvert.SerializeObject(agents.Content.ToArray());
                        
                        File.WriteAllText(this._agentJSON, json);

                    }
                    else
                    {
                        return new RepositoryResponse<Agent>() { IsSuccess = false, Message = "Error 101: Could not find specified agent" };
                    }

                    return new RepositoryResponse<Agent>() { IsSuccess = true, Content = a };
                }
                else
                {
                    return new RepositoryResponse<Agent>() { IsSuccess = false, Message = agents.Message };
                }
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Agent>() { Message = ex.Message, IsSuccess = false };
            }
        }

        public RepositoryResponse<List<Customer>> GetCustomers()
        {
            try
            {
                var customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(this._custJSON));

                return new RepositoryResponse<List<Customer>>() { IsSuccess = true, Content = customers };
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<List<Customer>>() { Message = ex.Message, IsSuccess = false };
            }
        }

        public RepositoryResponse<List<Customer>> GetCustomers(int agentId)
        {
            try
            {
                var customers = this.GetCustomers();

                if (customers.IsSuccess)
                {
                    return new RepositoryResponse<List<Customer>>() { IsSuccess = true, Content = customers.Content.Where(x => x.Agent_id == agentId).ToList() };
                }
                else
                {
                    return new RepositoryResponse<List<Customer>>() { IsSuccess = false, Message = customers.Message };
                }
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<List<Customer>>() { Message = ex.Message, IsSuccess = false };
            }
        }

        public RepositoryResponse<Customer> InsertCustomer(Customer c)
        {
            try
            {
                var customers = this.GetCustomers();

                if (customers.IsSuccess)
                {
                    customers.Content.Add(c);

                    var json = JsonConvert.SerializeObject(customers.Content.ToArray());

                    File.WriteAllText(this._custJSON, json);

                    return new RepositoryResponse<Customer>() { IsSuccess = true, Content = c };
                }
                else
                {
                    return new RepositoryResponse<Customer>() { IsSuccess = false, Message = customers.Message };
                }
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Customer>() { Message = ex.Message, IsSuccess = false };
            }
        }

        public RepositoryResponse<Customer> UpdateCustomer(Customer c)
        {
            try
            {
                var customers = this.GetCustomers();

                if (customers.IsSuccess)
                {
                    var targetCust = customers.Content.Where(x => x._Id == c._Id).FirstOrDefault();

                    if (null != targetCust)
                    {
                        customers.Content.Remove(targetCust);
                        targetCust = c;
                        customers.Content.Add(targetCust);

                        var json = JsonConvert.SerializeObject(customers.Content.ToArray());

                        File.WriteAllText(this._custJSON, json);

                    }
                    else
                    {
                        return new RepositoryResponse<Customer>() { IsSuccess = false, Message = "Error 102: Could not find specified customer" };
                    }

                    return new RepositoryResponse<Customer>() { IsSuccess = true, Content = c };
                }
                else
                {
                    return new RepositoryResponse<Customer>() { IsSuccess = false, Message = customers.Message };
                }
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Customer>() { Message = ex.Message, IsSuccess = false };
            }
        }

        public RepositoryResponse<object> DeleteCustomer(int customerId)
        {
            try
            {
                var customers = this.GetCustomers();

                if (customers.IsSuccess)
                {
                    var targetCustomer = customers.Content.Where(x => x._Id == customerId).FirstOrDefault();

                    if (null != targetCustomer)
                    {
                        customers.Content.Remove(targetCustomer);

                        var json = JsonConvert.SerializeObject(customers.Content.ToArray());

                        File.WriteAllText(this._custJSON, json);

                        return new RepositoryResponse<object>() { IsSuccess = true, Message = "Delete Success" };
                    }
                    else
                    {
                        return new RepositoryResponse<object>() { IsSuccess = false, Message = "Error 103: Could not find customer to delete" };
                    }

                   
                }
                else
                {
                    return new RepositoryResponse<object>() { IsSuccess = false, Message = customers.Message };
                }
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<object>() { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreezingFruitFoot.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreezingFruitFoot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private IRepository _repo;

        public CustomersController(IRepository repo)
        {
            this._repo = repo;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<RepositoryResponse<List<Customer>>> Get()
        {
            try
            {
                return this._repo.GetCustomers();
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<List<Customer>> { Message = ex.Message, IsSuccess = false };
            }
        }

        // GET api/values/5
        [HttpGet("{agentId}")]
        public ActionResult<RepositoryResponse<List<Customer>>> Get(int agentId)
        {
            try
            {
                return this._repo.GetCustomers(agentId);
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<List<Customer>> { Message = ex.Message, IsSuccess = false };
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<RepositoryResponse<Customer>> Post([FromBody] Customer cust)
        {
            try
            {
                return this._repo.InsertCustomer(cust);
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Customer> { Message = ex.Message, IsSuccess = false };
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<RepositoryResponse<Customer>> Update([FromBody] Customer cust)
        {
            try
            {
                return this._repo.UpdateCustomer(cust);
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Customer> { Message = ex.Message, IsSuccess = false };
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<RepositoryResponse<object>> Delete(int id)
        {
            try
            {
                return this._repo.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<object> { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}

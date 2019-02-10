using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreezingFruitFoot.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreezingFruitFoot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {

        private IRepository _repo;

        public AgentsController(IRepository repo)
        {
            this._repo = repo;
        }

        // GET: api/Agents
        [HttpGet]
        public ActionResult<RepositoryResponse<List<Agent>>> Get()
        {
            try
            {
                return this._repo.GetAgents();
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<List<Agent>> { Message = ex.Message, IsSuccess = false };
            }
        }

        // GET: api/Agents/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<RepositoryResponse<Agent>> Get(int id)
        {
            try
            {
                return this._repo.GetAgent(id);
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Agent> { Message = ex.Message, IsSuccess = false };
            }
        }

        // POST: api/Agents
        [HttpPost]
        public ActionResult<RepositoryResponse<Agent>> Post([FromBody] Agent agent)
        {
            try
            {
                return this._repo.InsertAgent(agent);
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Agent> { Message = ex.Message, IsSuccess = false };
            }
        }

        // PUT: api/Agents
        [HttpPut]
        public ActionResult<RepositoryResponse<Agent>> Put([FromBody] Agent agent)
        {
            try
            {
                return this._repo.UpdateAgent(agent);
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<Agent> { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}

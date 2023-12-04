/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinkManager.Domain;
using LinkManager.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace LinkManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentTypesController : ControllerBase
    {
        private readonly AgentKindRepository _repository;

        public AgentTypesController(Context context)
        {
            _repository = new AgentKindRepository(context);
        }

        // GET: api/AgentTypes
        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AgentKind>>> GetAgentTypes()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/AgentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgentKind>> GetAgentType(int id)
        {
            var agentType = await _repository.GetAsync(id);

            if (agentType == null)
            {
                return NotFound();
            }

            return agentType;
        }

        // PUT: api/AgentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgentType(int id, AgentKind agentType)
        {
            if (id != agentType.Code)
            {
                return BadRequest();
            }

            bool ok = await _repository.UpdateAsync(agentType);

            if(ok)
            {
                return Ok();
            } 
            else
            {
                return NotFound();
            }
            
        }

        // POST: api/AgentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgentKind>> PostAgentType(AgentKind agentType)
        {
            await _repository.AddAsync(agentType);

            return CreatedAtAction("GetAgentType", new { id = agentType.Code }, agentType);
        }
        // DELETE: api/AgentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgentType(int id)
        {
            var agentType = await _repository.GetAsync(id);
            if (agentType == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(agentType.Code);
            

            return Ok();
        }
    }
}
*/
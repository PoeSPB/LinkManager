using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinkManager.Domain;
using LinkManager.Infrastructure;
/*
namespace LinkManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkTypesController : ControllerBase
    {
        private readonly LinkTypesRepository _repository;

        public LinkTypesController(Context context)
        {
            _repository = new LinkTypesRepository(context);
        }

        // GET: api/LinkTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinkType>>> GetAgentTypes()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/LinkTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkType>> GetAgentType(Guid id)
        {
            var linkType = await _repository.GetAsync(id);

            if (linkType == null)
            {
                return NotFound();
            }

            return linkType;
        }

        // PUT: api/LinkTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgentType(Guid id, LinkType linkType)
        {
            if (id != linkType.Id)
            {
                return BadRequest();
            }

            bool ok = await _repository.UpdateAsync(linkType);

            if (ok)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/LinkTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LinkType>> PostAgentType(LinkType linkType)
        {
            await _repository.AddAsync(linkType);

            return CreatedAtAction("GetAgentType", new { id = linkType.Id }, linkType);
        }

        // DELETE: api/LinkTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgentType(Guid id)
        {
            var linkType = await _repository.GetAsync(id);
            if (linkType == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(linkType.Id);


            return Ok();
        }
    }
}
*/
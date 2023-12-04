using Microsoft.AspNetCore.Mvc;
using LinkManager.Domain;
using LinkManager.Domain.DTO;
using LinkManager.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace LinkManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly Context _context;
        private readonly AgentsRepository _agentRepository;

        public AgentsController(Context context)
        {
            _context = context;
            _agentRepository = new AgentsRepository(context);
        }

        private AgentDTO ToAgentDTO(Agent agent)
        {
            AgentDTO agentDTO = new AgentDTO
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Descripion,
                ImgURL = agent.ImgURL,
                Status = agent.Status,
                RegisteredTime = agent.RegisteredTime,
                AgentKindDTO = ToAgentKindDTO(agent.AgentKind)
                //LinkedAgentDTOs = ToLinkedAgentDTO(agent),
            };
            return agentDTO;
        }

        private List<LinkLightDTO> ToLinkLightDTO(Agent agent)
        {
            var linkLightDTOs = new List<LinkLightDTO>();
            foreach (var link in agent.Links)
            {
                var linkLightDTO = new LinkLightDTO
                {
                    LinkDescription = link.Description,
                    LinkStatus = link.Status,
                    LinkEndTypeDTO =
                    {
                        Code = link.LinkEndType.Code,
                        Description = link.LinkEndType.Description,
                        Name = link.LinkEndType.Name
                    }
                };
                linkLightDTOs.Add(linkLightDTO);
            }
            return linkLightDTOs;
        }

        private List<LinkedAgentDTO> ToLinkedAgentDTO(Agent agent)
        {
            var linkedAgentDTO = new List<LinkedAgentDTO>();
            //Выполняем группировку связей по связанным агентам
            var agents = agent.Links.GroupBy(l => l.Agent);
            //Делаем цикл по уникальным связанным агентам
            foreach(var groupedAgent in agents)
            {
                //Для каждого агента заполняем LinkLightDTO
                //Помещаем созданного связанного агента в List<LinkedAgentDTO>

                var agentDTO = ToAgentDTO(agent);
                agentDTO.LinkLightDTOs = ToLinkLightDTO(groupedAgent.Key);
            }

            //Возращаем List<LinkedAgentDTO>

            return linkedAgentDTO;
        }
        private List<LinkEndDTO> ToLinksDTO(List<LinkEnd> linkEnds)
        {
            List<LinkEndDTO> linkEndDTOs = new List<LinkEndDTO>();
            foreach (var linkEnd in linkEnds)
            {
                LinkEndDTO linkEndDTO = new LinkEndDTO
                {
                    Id = linkEnd.Id,
                    Description = linkEnd.Description,
                    AgentChecked = linkEnd.AgentChecked,
                    CreationTime = linkEnd.CreationTime,
                    CheckedTime = linkEnd.CheckedTime,
                    CloseTime = linkEnd.CloseTime,
                    ActiveLinkFlag = linkEnd.ActiveLinkFlag,
                    Status = linkEnd.Status,
                    Out = new LinkEndDTO
                    {
                        Id = linkEnd.Out.Id,
                        Description = linkEnd.Out.Description,
                        AgentChecked = linkEnd.Out.AgentChecked,
                        CreationTime = linkEnd.Out.CreationTime,
                        CheckedTime = linkEnd.Out.CheckedTime,
                        CloseTime = linkEnd.Out.CloseTime,
                        ActiveLinkFlag = linkEnd.Out.ActiveLinkFlag,
                        Status = linkEnd.Out.Status
                    }
                };
                linkEndDTO.Out.In = linkEndDTO;
                linkEndDTO.In = linkEndDTO.Out;
                linkEndDTO.Out.Out = linkEndDTO;

                linkEndDTOs.Add(linkEndDTO);
            }
            return linkEndDTOs;
        }
        private AgentKindDTO ToAgentKindDTO(AgentKind agentKind)
        {
            AgentKindDTO agentKindDTO = new AgentKindDTO
            {
                Code = agentKind.Code,
                Name = agentKind.Name,
                Description = agentKind.Description
            };
            return agentKindDTO;
        }

        // GET: api/Agents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgentDTO>>> GetAgents()
        {
            var agents = await _agentRepository.GetAllAsync();
            List<AgentDTO> agentDTOs = new List<AgentDTO>();
            foreach (var agent in agents)
            {
                agentDTOs.Add(ToAgentDTO(agent));
            }
            return agentDTOs;
        }

        // GET: api/Agents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgentDTO>> GetAgent(Guid id)
        {
            var agent = await _agentRepository.GetAsync(id);

            if (agent == null)
            {
                return NotFound();
            }

            return ToAgentDTO(agent);
        }

        [HttpGet("links/{id}")]
        public async Task<ActionResult<AgentDTO>> GetAgentWithLinks(Guid id)
        {
            var agent = await _agentRepository.GetWithLinks(id);
            /*
            if (agent == null)
            {
                return NotFound();
            }
            */
            return ToAgentDTO(agent);
            
        }
/*
        // PUT: api/Agents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgent(Guid id, Agent agent)
        {
            if (id != agent.Id)
            {
                return BadRequest();
            }

            _context.Entry(agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
*/
        // POST: api/Agents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Agent>> PostAgent(Agent agent)
        {
            await _agentRepository.AddAsync(agent);

            //return CreatedAtAction("GetAgent", new { id = agent.Id }, agent);
            return Ok();
        }

        // DELETE: api/Agents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgent(Guid id)
        {
            var agent = await _agentRepository.GetAsync(id);
            if (agent == null)
            {
                return NotFound();
            }

            await _agentRepository.DeleteAsync(agent.Id);

            return Ok();
        }

        private bool AgentExists(Guid id)
        {
            return _context.Agents.Any(e => e.Id == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkManager.Infrastructure
{
    public class AgentsRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public AgentsRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Agent>> GetAllAsync()
        {
            var agent = await _context.Agents
                .Include(a => a.AgentKind)
                .OrderBy(a => a.Name)
                .ToListAsync();
            return agent;
        }
        public async Task<Agent> GetAsync(Guid id)
        {
            var agent = await _context.Agents
                .Include(a => a.AgentKind)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
            return agent;
        }
        public async Task AddAsync(Agent agent)
        {           
            AgentKind agentType = _context.AgentKinds.Where(i => i.Code == agent.AgentKind.Code).FirstOrDefault();
            agent.ObjectId = agent.ObjectId;
            agent.ImgURL = "";
            agent.Status = AgentStatus.Acticve;
            agent.RegisteredTime = DateTime.Now;
            agentType.Agents.Add(agent);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            Agent agent = await _context.Agents.FindAsync(id);
            _context.Remove(agent);
            await _context.SaveChangesAsync();
        }
        public async Task<Agent> GetWithLinks(Guid id)
        {
            var agent = await _context.Agents
                  .Include(a => a.AgentKind)
                  .Include(a => a.Links).ThenInclude(l => l.LinkEndType)
                  .Include(a => a.Links).ThenInclude(end2 => end2.In)
                  .ThenInclude(end2 => end2.Agent)
                  .Where(a => a.Id == id)
                  .FirstOrDefaultAsync();
            return agent;
        }
    }
}

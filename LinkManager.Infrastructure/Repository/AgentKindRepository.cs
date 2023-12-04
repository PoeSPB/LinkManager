using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkManager.Infrastructure
{
    public class AgentKindRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public AgentKindRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<AgentKind>> GetAllAsync()
        {
            return await _context.AgentKinds.OrderBy(a => a.Name).ToListAsync();
        }
        public async Task<AgentKind> GetAsync(int id)
        {
            return await _context.AgentKinds.FindAsync(id);
        }
        public async Task<bool> UpdateAsync(AgentKind agentKind)
        {
            AgentKind existAgent = await _context.AgentKinds.FindAsync(agentKind.Code);
            _context.Entry(existAgent).CurrentValues.SetValues(agentKind);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentKindExists(agentKind.Code))
                {
                    return false;
                } 
            }
            return true;
        }

        public async Task AddAsync(AgentKind agentType)
        {
            await _context.AgentKinds.AddAsync(agentType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            AgentKind agentType = await _context.AgentKinds.FindAsync(id);
            _context.Remove(agentType);
            await _context.SaveChangesAsync();
        }



        private bool AgentKindExists(int code)
        {
            return _context.AgentKinds.Any(e => e.Code == code);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkManager.Domain;
using LinkManager.Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace LinkManager.Infrastructure
{
    public class LinksRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public LinksRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<LinkEnd>> GetAllAsync()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<List<LinkEnd>> GetLinksForAgentAsync(Guid id)
        {
            return await _context.Links
                .Include(end2 => end2.In)
                .Where(l => l.AgentId == id).ToListAsync();
        }

        public async Task AddAsync(NewLinkDTO newLinkDTO)
        {
            AgentsRepository agentsRepository = new AgentsRepository(this.UnitOfWork);

            var a1 = await agentsRepository.GetAsync(newLinkDTO.Agent1Id);
            var a2 = await agentsRepository.GetAsync(newLinkDTO.Agent2Id);

            LinkEnd link1 = new LinkEnd()
            {
                Id = Guid.NewGuid(),
                LinkEndTypeId = newLinkDTO.LinkEnd1KindCode,
                Description = "End 1",
                AgentChecked = true,
                CreationTime = DateTime.Now,
                CheckedTime = DateTime.Now,
                ActiveLinkFlag = false,
                Status = LinkStatus.Initial
            };
            LinkEnd link2 = new LinkEnd()
            {
                Id = Guid.NewGuid(),
                LinkEndTypeId = newLinkDTO.LinkEnd2KindCode,
                Description = "End 2",
                AgentChecked = false,
                CreationTime = DateTime.Now,
                ActiveLinkFlag = false,
                Status = LinkStatus.Initial
            };

            //link1.Out = link2;
            //link1.In = link2;
            //link2.Out = link1;
            //link2.In = link1;

            link1.LinkOutId = link2.Id;
            link2.LinkOutId = link1.Id;

            //a1.Links.Add(link1);
            //a2.Links.Add(link2);

            _context.Links.Add(link1);

            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkManager.Infrastructure
{
    public class LinkTypesRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public LinkTypesRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<LinkType>> GetAllAsync()
        {
            return await _context.LinkTypes.OrderBy(a => a.Name).ToListAsync();
        }
        public async Task<LinkType> GetAsync(Guid id)
        {
            return await _context.LinkTypes.FindAsync(id);
        }
        public async Task<bool> UpdateAsync(LinkType linkType)
        {
            LinkType existLink = await _context.LinkTypes.FindAsync(linkType.Id);
            _context.Entry(existLink).CurrentValues.SetValues(linkType);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkTypeExists(linkType.Id))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task AddAsync(LinkType linkType)
        {
            await _context.LinkTypes.AddAsync(linkType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            LinkType linkType = await _context.LinkTypes.FindAsync(id);
            _context.Remove(linkType);
            await _context.SaveChangesAsync();
        }



        private bool LinkTypeExists(int id)
        {
            return _context.LinkTypes.Any(e => e.Id == id);
        }
    }
}

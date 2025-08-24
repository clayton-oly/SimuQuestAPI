using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class OptionRepository : IOptionRepository
    {
        private readonly SimuQuestDbContext _context;

        public OptionRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(Option option)
        {
            await _context.Options.AddAsync(option);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Option>> GetAll()
        {
            return await _context.Options.ToListAsync();
        }

        public async Task<Option> GetById(int id)
        {
            return await _context.Options.FindAsync(id);
        }

        public async Task Update(Option option)
        {
            _context.Options.Update(option);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var option = await _context.Options.FirstOrDefaultAsync(e => e.Id == id);

            if (option != null)
            {
                _context.Options.Remove(option);
                await _context.SaveChangesAsync();
            }

        }
    }
}

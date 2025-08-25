using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SimuQuestDbContext _context;
        public QuestionRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _context.Questions.Include(q => q.SimulatedExam).ToListAsync();
        }

        public async Task<Question> GetById(int id)
        {
            return await _context.Questions.Include(q => q.SimulatedExam).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task Update(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var question = await _context.SimulatedExams.FirstOrDefaultAsync(e => e.Id == id);

            if (question != null)
            {
                _context.SimulatedExams.Remove(question);
                await _context.SaveChangesAsync();
            }

        }
    }
}

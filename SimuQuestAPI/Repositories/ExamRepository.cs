using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly SimuQuestDbContext _context;
        public ExamRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(Exam exam)
        {
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Exam>> GetAll()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<Exam> GetById(int id)
        {
            return await _context.Exams.FindAsync(id);
        }

        public async Task Update(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(e => e.Id == id);

            if (exam != null)
            {
                _context.Exams.Remove(exam);
                await _context.SaveChangesAsync();
            }

        }
    }
}

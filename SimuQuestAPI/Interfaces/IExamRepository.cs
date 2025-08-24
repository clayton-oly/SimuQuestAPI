using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface IExamRepository
    {
        Task Add(Exam exam);
        Task<IEnumerable<Exam>> GetAll();
        Task<Exam> GetById(int id);
        Task Update(Exam exam);
        Task Delete(int id);
    }
}

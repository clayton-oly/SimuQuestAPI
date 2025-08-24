using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface IQuestionRepository
    {
        Task Add(Question question);
        Task<IEnumerable<Question>> GetAll();
        Task<Question> GetById(int id);
        Task Update(Question question);
        Task Delete(int id);
    }
}

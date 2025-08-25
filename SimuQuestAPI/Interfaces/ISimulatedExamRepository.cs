using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface ISimulatedExamRepository
    {
        Task Add(SimulatedExam exam);
        Task<IEnumerable<SimulatedExam>> GetAll();
        Task<SimulatedExam> GetById(int id);
        Task Update(SimulatedExam exam);
        Task Delete(int id);
    }
}

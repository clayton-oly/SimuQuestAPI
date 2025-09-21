using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User>GetByLoginAsync(string email, string senha);
    }
}
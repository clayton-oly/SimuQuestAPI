using SimuQuestAPI.Models;

namespace SimuQuestAPI.DTOs
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }
}

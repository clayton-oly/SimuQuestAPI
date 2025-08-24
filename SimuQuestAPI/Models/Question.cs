using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimuQuestAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public string? Explicacao { get; set; }
        public int Ordem { get; set; }

        public int SimuladoId { get; set; }
        public Exam Exam { get; set; }

        public ICollection<Option> Options { get; set; } = new List<Option>();
    }
}

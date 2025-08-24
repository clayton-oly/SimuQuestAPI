using System.ComponentModel.DataAnnotations;

namespace SimuQuestAPI.Models
{
    public class SimulatedResult
    {
        [Key]
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        //public string UsuarioId { get; set; } // Se tiver autenticação
        public DateTime DataConclusao { get; set; } = DateTime.UtcNow;
        public int Pontuacao { get; set; } // Ex: 10/15
        public ICollection<AnsweredQuestion> AnsweredQuestions { get; set; } = new List<AnsweredQuestion>();
    }
}

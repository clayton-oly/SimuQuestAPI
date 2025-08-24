namespace SimuQuestAPI.Models
{
    public class SimuladoResult
    {
        public int Id { get; set; }
        public int SimuladoId { get; set; }
        public Exam Exam { get; set; }

        public string UsuarioId { get; set; } // Se tiver autenticação
        public DateTime DataConclusao { get; set; } = DateTime.UtcNow;
        public int Pontuacao { get; set; } // Ex: 10/15
        public ICollection<AnsweredQuestion> AnsweredQuestions { get; set; } = new List<AnsweredQuestion>();
    }
}

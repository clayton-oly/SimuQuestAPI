namespace SimuQuestAPI.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public bool Correta { get; set; }
        public int Ordem { get; set; }

        public int QuestaoId { get; set; }
        public Question Question { get; set; }
    }
}

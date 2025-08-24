namespace SimuQuestAPI.Models
{
    public class AnsweredQuestion
    {
        public int Id { get; set; }

        public int QuestaoId { get; set; }
        public Question Question { get; set; }


        public int SimuladoResultId { get; set; }
        public SimuladoResult SimuladoResult { get; set; }

        public ICollection<SelectedOption> SelectedOptions { get; set; } = new List<SelectedOption>();
        public bool Acertou { get; set; } 
    }
}

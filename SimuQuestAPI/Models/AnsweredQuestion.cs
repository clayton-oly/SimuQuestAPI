namespace SimuQuestAPI.Models
{
    public class AnsweredQuestion
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }


        public int SimulatedResultId { get; set; }
        public SimulatedResult SimulatedResult { get; set; }

        public ICollection<SelectedOption> SelectedOptions { get; set; } = new List<SelectedOption>();
        public bool Acertou { get; set; } 
    }
}

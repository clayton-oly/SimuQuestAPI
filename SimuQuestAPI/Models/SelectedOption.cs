namespace SimuQuestAPI.Models
{
    public class SelectedOption
    {
        public int Id { get; set; }

        public int OptionId { get; set; }
        public Option Option { get; set; }

        public int AnsweredQuestionId { get; set; }
        public AnsweredQuestion AnsweredQuestion { get; set; }
    }
}

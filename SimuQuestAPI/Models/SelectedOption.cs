namespace SimuQuestAPI.Models
{
    public class SelectedOption
    {
        public int Id { get; set; }
        public int AlternativaId { get; set; }
        public Option Option { get; set; }

        public int QuestaoRespondidaId { get; set; }
        public AnsweredQuestion AnsweredQuestion { get; set; }
    }
}

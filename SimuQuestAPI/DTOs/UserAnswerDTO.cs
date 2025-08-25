namespace SimuQuestAPI.DTOs
{
    public class UserAnswerDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int SimulatedResultId { get; set; }
        public bool IsCorrect { get; set; }
    }
}

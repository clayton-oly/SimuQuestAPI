using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetAll()
        {

            var questions = await _questionRepository.GetAll();

            var questionsDTO = questions
                .Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Texto = q.Texto,
                    Explicacao = q.Explicacao,
                    Ordem = q.Ordem,
                    ExamId = q.ExamId,
                    NomeExame = q.Exam.Nome
                });

            return Ok(questionsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDTO>> GetById(int id)
        {
            var question = await _questionRepository.GetById(id);

            var questionDTO = new QuestionDTO
            {
                Id = question.Id,
                Texto = question.Texto,
                Explicacao = question.Explicacao,
                Ordem = question.Ordem,
                ExamId = question.ExamId,
                NomeExame = question.Exam.Nome
            };

            return Ok(questionDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] QuestionDTO questionDTO)
        {
            var question = new Question
            {
                Id = questionDTO.Id,
                Texto = questionDTO.Texto,
                Explicacao = questionDTO.Explicacao,
                Ordem = questionDTO.Ordem,
                ExamId = questionDTO.ExamId
            };

            await _questionRepository.Add(question);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, QuestionDTO questionDTO)
        {
            var question = new Question
            {
                Id = questionDTO.Id,
                Texto = questionDTO.Texto,
                Explicacao = questionDTO.Explicacao,
                Ordem = questionDTO.Ordem,
                ExamId = questionDTO.ExamId
            };

            await _questionRepository.Update(question);

            return Ok(question);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionRepository.Delete(id);

            return Ok();
        }
    }
}

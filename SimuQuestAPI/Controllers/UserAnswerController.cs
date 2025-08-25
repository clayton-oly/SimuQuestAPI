using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnswerController : ControllerBase
    {
        private readonly IUserAnswerRepository _userAnswerRepository;
        public UserAnswerController(IUserAnswerRepository userAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userAnswer = await _userAnswerRepository.GetAll();

            var userAnswerDTO = userAnswer.
                Select(u => new UserAnswerDTO
                {
                    SimulatedResultId = u.SimulatedResultId,
                    Id = u.Id,
                    IsCorrect = u.IsCorrect,
                    QuestionId = u.QuestionId,
                });

            return Ok(userAnswerDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userAnswer = await _userAnswerRepository.GetById(id);

            var userAnswerDTO = new UserAnswerDTO
            {
                Id = userAnswer.Id,
                IsCorrect = userAnswer.IsCorrect,
                QuestionId = userAnswer.QuestionId,
                SimulatedResultId = userAnswer.SimulatedResultId,
            };

            return Ok(userAnswerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAnswerDTO userAnswerDTO)
        {
            var userAnswer = new UserAnswer
            {
                Id = userAnswerDTO.Id,
                IsCorrect = userAnswerDTO.IsCorrect,
                QuestionId = userAnswerDTO.QuestionId,
                SimulatedResultId = userAnswerDTO.SimulatedResultId,
            };

            await _userAnswerRepository.Add(userAnswer);
            return Ok(userAnswerDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserAnswerDTO userAnswerDTO)
        {
            var userAnswer = new UserAnswer
            {
                Id = userAnswerDTO.Id,
                IsCorrect = userAnswerDTO.IsCorrect,
                QuestionId = userAnswerDTO.QuestionId,
                SimulatedResultId = userAnswerDTO.SimulatedResultId,
            };

            await _userAnswerRepository.Update(userAnswer);
            return Ok(userAnswerDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userAnswerRepository.Delete(id);
            return Ok();
        }
    }
}

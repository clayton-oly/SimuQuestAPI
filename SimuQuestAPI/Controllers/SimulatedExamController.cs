using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulatedExamController : ControllerBase
    {
        private readonly ISimulatedExamRepository _examRepository;

        public SimulatedExamController(ISimulatedExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOs.SimulatedExamDTO>>> GetAll()
        {
            var exams = await _examRepository.GetAll();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DTOs.SimulatedExamDTO>> GetById(int id)
        {
            var exam = await _examRepository.GetById(id);
            return Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTOs.SimulatedExamDTO examDTO)
        {
            var exam = new Models.SimulatedExam
            {
                Id = examDTO.Id,
                Nome = examDTO.Nome,
                Descricao = examDTO.Descricao,
            };

            await _examRepository.Add(exam);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DTOs.SimulatedExamDTO examDTO)
        {
            var exam = new Models.SimulatedExam
            {
                Id = examDTO.Id,
                Nome = examDTO.Nome,
                Descricao = examDTO.Descricao,
            };

            await _examRepository.Update(exam);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _examRepository.Delete(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;

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
        public async Task<ActionResult<IEnumerable<SimulatedExamDTO>>> GetAll()
        {
            var exams = await _examRepository.GetAll();

            var examDTOs = exams
              .Select(s => new SimulatedExamDTO
              {
                  Descricao = s.Descricao,
                  Nome = s.Nome,
                  Id = s.Id,

                  Questions = s.Questions.Select(q => new QuestionDTO
                  {
                      Id = q.Id,
                      Texto = q.Statement,
                  }).ToList()
              }).ToList();

            return Ok(examDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SimulatedExamDTO>> GetById(int id)
        {
            var exam = await _examRepository.GetById(id);

            var examDTO = new SimulatedExamDTO
            {
                Id = exam.Id,
                Nome = exam.Nome,
                Descricao = exam.Descricao,
                DataCriacao = exam.DataCriacao,
                Questions = exam.Questions.Select(q => new QuestionDTO
                {
                    Id= q.Id,
                    Ordem = q.Ordem,
                    Texto   = q.Statement,

                    Options = q.Options.Select(o => new OptionDTO
                    {
                        Id = o.Id,
                        Texto = o.Texto,
                        Correta = o.IsCorrect,
                        Ordem = o.Ordem,
                    }).ToList(),
                }).ToList(),
                
            };

            return Ok(examDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SimulatedExamDTO examDTO)
        {
            var exam = new Models.SimulatedExam
            {
                Id = examDTO.Id,
                Nome = examDTO.Nome,
                Descricao = examDTO.Descricao,
            };

            await _examRepository.Add(exam);
            return Ok(examDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SimulatedExamDTO examDTO)
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

using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;

namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _usuarioRepository;

        public LoginController(IUserRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDTO login)
        {
            var usuario = await _usuarioRepository.GetByLoginAsync(login.Email, login.Senha);

            if (usuario == null) return Unauthorized();

            return Ok(usuario);
        }

    }
}

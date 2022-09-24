using CelsoGuitarsAuthentication.Application.Usuario.DTO;
using CelsoGuitarsAuthentication.Application.Usuario.Handler.Command;
using CelsoGuitarsAuthentication.Application.Usuario.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CelsoGuitarsAuthentication.API.Controllers.Usuario
{
    [Route("api/[controller]"), ApiController, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("ValidarLogin"), AllowAnonymous]
        public async Task<IActionResult> ValidarLogin([FromServices] IConfiguration configuration, UsuarioLoginInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new ValidarLoginUsuarioCommand(dto));

            if (result.Usuario.Valido)
            {
                return Ok($"Bearer {GenerateToken(configuration, result.Usuario.ID.Value)}");
            }
            else
            {
                return Unauthorized(result.Usuario.Mensagem);
            }
        }

        private static string GenerateToken(IConfiguration configuration, Guid id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["TokenSecret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, id.ToString()),
                new Claim("role", "User")
            };

            var token = new JwtSecurityToken(
                    issuer: configuration["Issuer"],
                    audience: configuration["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllUsuarioQuery()));
        }

        [HttpPost, Route("Criar")]
        public async Task<IActionResult> Criar(UsuarioInputDTO dto)
        {
            var result = await _mediator.Send(new CriarUsuarioCommand(dto));

            return Created($"{result.Usuario.ID}", result.Usuario);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(UsuarioUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new AtualizarUsuarioCommand(dto));

            return Ok(result.Usuario);
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(Guid usuarioID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(new RemoverUsuarioCommand(usuarioID));

            return NoContent();
        }
    }
}

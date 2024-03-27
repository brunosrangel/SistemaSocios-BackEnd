using Microsoft.AspNetCore.Mvc;
using SistemaSocio.Service.interfaces;
using SistemaSocio.Service.Services;
using SistemaSocios.Core.Model.Usuario;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using ZstdSharp.Unsafe;

namespace SistemaSocios.Webapi.Controllers
{
    [SwaggerTag("Usuários")]
    public class UsuarioController : BaseController<UsuarioModel, IEntityService<UsuarioModel>>
    {
        private readonly IUserService<UsuarioModel> _UService;
        private readonly ITokenService _tokenService;
        public UsuarioController(ITokenService tokenService, IEntityService<UsuarioModel> usuarioService, IUserService<UsuarioModel> UService) : base(usuarioService)
        {
            _UService = UService;
            _tokenService = tokenService;
                
        }
        [HttpGet("login")]
        public async Task<OkObjectResult> Login(string user, string pass)
        {
           var data = await _UService.EfetuaLogin(user, pass);
            // Construa um dicionário com as informações que deseja incluir no token
            var claims = new Dictionary<string, string>
        {
            { "userId", data.Id.ToString() },
            { "username", data.email }
        };
            var token = _tokenService.GenerateToken(claims);

            return Ok(new { accessToken = token });


        }

        // Implementação do método abstrato para obter o ID da entidade
        protected override string GetEntityId(UsuarioModel entity) => entity.Id.ToString();
    }
}
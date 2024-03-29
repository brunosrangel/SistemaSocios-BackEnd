using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq.Expressions;
using System.Xml;
using Xis.Generic.DataAccess.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    [SwaggerTag("Usuários")]
    public class UsuarioController : BaseController<UsuarioModel, IGenericService<UsuarioModel>>
    {
        private readonly IGenericService<UsuarioModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<UsuarioModel> _loger;
        public UsuarioController(ITokenService tokenService, ILogger<UsuarioModel> loger, IGenericService<UsuarioModel> genericService) : base(genericService, loger)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login(string user, string pass)
        {
            var usr = new UsuarioModel { email = user };
            Expression<Func<UsuarioModel, bool>> FiltrarUsuario = entity => entity.email == user;
            Expression<Func<UsuarioModel, bool>> FiltrarUsuarioSenha = entity => entity.email == user && entity.senha == pass;
            var VerificaUsario = await _service.QuerySingleAsync(FiltrarUsuario);
            var verificaSenha = await _service.QuerySingleAsync(FiltrarUsuarioSenha);

            var ValidaEmail = FiltrarUsuario.Compile()(new UsuarioModel { email = user });
            if (!ValidaEmail)
            {
                return BadRequest("Email Não cadastrado");
            }
            else
            {
                bool resultadoEmailSenha = FiltrarUsuarioSenha.Compile()(new UsuarioModel { email = user, senha = pass });
                if (!resultadoEmailSenha) { return BadRequest("Senha Invalida"); }
                else
                {
                    // Construa um dicionário com as informações que deseja incluir no token
                    var claims = new Dictionary<string, string>
                    {
                        { "userId", verificaSenha.Id.ToString() },
                        { "username", verificaSenha.email }
                    };
                    var token = _tokenService.GenerateToken(claims);
                    return Ok(new { accessToken = token });
                }

            }





        }

        // Implementação do método abstrato para obter o ID da entidade
        protected override string GetEntityId(UsuarioModel entity) => entity.Id.ToString();
    }
}

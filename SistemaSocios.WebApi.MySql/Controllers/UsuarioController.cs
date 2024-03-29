using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq.Expressions;
using Xis.Generic.DataAccess.Service;


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
            try
            {

                var verificaSenha = await _service.QuerySingleAsync(FiltrarUsuario);
                var verificaSenha2 = await _service.QueryAsync(FiltrarUsuario);
                var ValidaEmail = FiltrarUsuario.Compile()(new UsuarioModel { email = user });
                if (!ValidaEmail)
                {
                    return BadRequest("Email Não cadastrado");
                }
                else
                {
                    bool resultadoEmailSenha = FiltrarUsuario.Compile()
                        (new UsuarioModel { senha = pass });

                    bool validaHash = new ControleSenha.ControleSenha().VerifyPassword(pass, verificaSenha.senha);
                    if (!validaHash) { return BadRequest("Senha Invalida"); }
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
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }







        }

        // Implementação do método abstrato para obter o ID da entidade
        protected override string GetEntityId(UsuarioModel entity) => entity.Id.ToString();
    }
}

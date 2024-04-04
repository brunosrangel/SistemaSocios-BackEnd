using Microsoft.AspNetCore.Mvc;
using SistemaSocios.WebApi.MySqlN.model;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics.Eventing.Reader;
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
        public UsuarioController(ITokenService tokenService, ILogger<UsuarioModel> loger,
                                IGenericService<UsuarioModel> genericService) : base(genericService, loger, tokenService)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var usr = new UsuarioModel { email = login.login };
            Expression<Func<UsuarioModel, bool>> FiltrarUsuario = entity => entity.email == login.login;
            try
            {

                var verificaSenha = await _service.QuerySingleAsync(FiltrarUsuario);
                var verificaSenha2 = await _service.QueryAsync(FiltrarUsuario);
                if (verificaSenha == null)
                {
                    return Ok(new ApiResponse<object>
                    {
                        Success = false,
                        ErrorMessage = "Email não cadastrado",
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    });
                }
                else
                {
                    bool validaHash = _tokenService.VerifyPassword(login.password, _tokenService.HashPassword(login.password));
                    if (!validaHash)
                    {
                        return Ok(new ApiResponse<object>
                        {
                            Success = false,
                            ErrorMessage = "Senha Invalida",
                            StatusCode = System.Net.HttpStatusCode.BadRequest
                        });
                    }
                    else
                    {
                        // Construa um dicionário com as informações que deseja incluir no token
                        var claims = new Dictionary<string, string>
                    {
                        { "userId", verificaSenha.Id.ToString() },
                        { "login", verificaSenha.email },
                        {"nomeUsuario", verificaSenha.nomeUsuario},

                    };
                        var token = _tokenService.GenerateToken(claims);
                        return Ok(new ApiResponse<object>
                        {
                            Data = token,
                            Success = true,
                            StatusCode = System.Net.HttpStatusCode.OK,
                        });
                    }

                }
            }
            catch (Exception ex)
            {

                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            }







        }

        // Implementação do método abstrato para obter o ID da entidade
        protected override string GetEntityId(UsuarioModel entity) => entity.Id.ToString();
    }
}

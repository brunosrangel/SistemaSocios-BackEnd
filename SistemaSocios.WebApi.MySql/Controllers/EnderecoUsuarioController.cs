using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class EnderecoUsuarioController : BaseController<EnderecoUsuarioModel, IGenericService<EnderecoUsuarioModel>>
    {
        private readonly IGenericService<EnderecoUsuarioModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<EnderecoUsuarioModel> _loger;
        public EnderecoUsuarioController(ITokenService tokenService, ILogger<EnderecoUsuarioModel> loger, IGenericService<EnderecoUsuarioModel> genericService) : base(genericService, loger)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(EnderecoUsuarioModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

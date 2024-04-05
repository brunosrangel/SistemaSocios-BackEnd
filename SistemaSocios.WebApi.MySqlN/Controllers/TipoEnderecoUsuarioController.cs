using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class TipoEnderecoUsuarioController : BaseController<TipoEnderecoUsuarioModel, IGenericService<TipoEnderecoUsuarioModel>>
    {
        private readonly IGenericService<TipoEnderecoUsuarioModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<TipoEnderecoUsuarioModel> _loger;
        public TipoEnderecoUsuarioController(ITokenService tokenService, ILogger<TipoEnderecoUsuarioModel> loger,
                                  IGenericService<TipoEnderecoUsuarioModel> genericService) : base(genericService, loger, tokenService)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(TipoEnderecoUsuarioModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

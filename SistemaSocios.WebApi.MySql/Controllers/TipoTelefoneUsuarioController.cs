using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class TipoTelefoneUsuarioController : BaseController<TipoTelefoneUsuarioModel, IGenericService<TipoTelefoneUsuarioModel>>
    {
        private readonly IGenericService<TipoTelefoneUsuarioModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<TipoTelefoneUsuarioModel> _loger;
        public TipoTelefoneUsuarioController(ITokenService tokenService, ILogger<TipoTelefoneUsuarioModel> loger,
                                  IGenericService<TipoTelefoneUsuarioModel> genericService) : base(genericService, loger)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(TipoTelefoneUsuarioModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

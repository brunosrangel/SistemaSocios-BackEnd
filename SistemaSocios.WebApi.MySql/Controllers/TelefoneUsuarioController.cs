using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class TelefoneUsuarioController : BaseController<TelefoneUsuarioModel, IGenericService<TelefoneUsuarioModel>>
    {
        private readonly IGenericService<TelefoneUsuarioModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<TelefoneUsuarioModel> _loger;
        public TelefoneUsuarioController(ITokenService tokenService, ILogger<TelefoneUsuarioModel> loger,
                                  IGenericService<TelefoneUsuarioModel> genericService) : base(genericService, loger)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(TelefoneUsuarioModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

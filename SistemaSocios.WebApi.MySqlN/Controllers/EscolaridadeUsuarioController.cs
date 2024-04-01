using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{

    public class EscolaridadeUsuarioController : BaseController<EscolaridadeUsuarioModel, IGenericService<EscolaridadeUsuarioModel>>
    {
        private readonly IGenericService<EscolaridadeUsuarioModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<EscolaridadeUsuarioModel> _loger;
        public EscolaridadeUsuarioController(ITokenService tokenService, ILogger<EscolaridadeUsuarioModel> loger, IGenericService<EscolaridadeUsuarioModel> genericService) : base(genericService, loger, tokenService)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(EscolaridadeUsuarioModel entity)
        {
            return entity.Id.ToString();
        }
    }
}



using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{

    public class StatusMensalidadeController : BaseController<StatusMensalidadeModel, IGenericService<StatusMensalidadeModel>>
    {
        private readonly IGenericService<StatusMensalidadeModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<StatusMensalidadeModel> _loger;
        public StatusMensalidadeController(ITokenService tokenService, ILogger<StatusMensalidadeModel> loger, IGenericService<StatusMensalidadeModel> genericService) : base(genericService, loger, tokenService)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(StatusMensalidadeModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

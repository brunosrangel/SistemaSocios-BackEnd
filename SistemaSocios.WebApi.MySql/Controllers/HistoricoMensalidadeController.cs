using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class HistoricoMensalidadeController : BaseController<HistoricoMensalidadesModel, IGenericService<HistoricoMensalidadesModel>>
    {
        private readonly IGenericService<HistoricoMensalidadesModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<HistoricoMensalidadesModel> _loger;
        public HistoricoMensalidadeController(ITokenService tokenService, ILogger<HistoricoMensalidadesModel> loger, IGenericService<HistoricoMensalidadesModel> genericService) : base(genericService, loger)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(HistoricoMensalidadesModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

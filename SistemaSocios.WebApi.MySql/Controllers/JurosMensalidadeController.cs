using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class JurosMensalidadeController : BaseController<JurosMensalidadeModel, IGenericService<JurosMensalidadeModel>>
    {
        private readonly IGenericService<JurosMensalidadeModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<JurosMensalidadeModel> _loger;
        public JurosMensalidadeController(ITokenService tokenService, ILogger<JurosMensalidadeModel> loger,
                                  IGenericService<JurosMensalidadeModel> genericService) : base(genericService, loger)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(JurosMensalidadeModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

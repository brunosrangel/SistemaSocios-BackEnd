using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class ValorMensalidadeController : BaseController<ValorMensalidadeModel, IGenericService<ValorMensalidadeModel>>
    {
        private readonly IGenericService<ValorMensalidadeModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<ValorMensalidadeModel> _loger;
        public ValorMensalidadeController(ITokenService tokenService, ILogger<ValorMensalidadeModel> loger,
                                  IGenericService<ValorMensalidadeModel> genericService) : base(genericService, loger, tokenService)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(ValorMensalidadeModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

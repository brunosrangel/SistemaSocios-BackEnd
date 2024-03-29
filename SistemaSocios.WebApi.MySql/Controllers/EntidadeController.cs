using Xis.Generic.DataAccess.Service;


namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class EntidadeController : BaseController<EntidadeModel, IGenericService<EntidadeModel>>
    {
        private readonly IGenericService<EntidadeModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<EntidadeModel> _loger;
        public EntidadeController(ITokenService tokenService, ILogger<EntidadeModel> loger, IGenericService<EntidadeModel> genericService) : base(genericService, loger)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(EntidadeModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

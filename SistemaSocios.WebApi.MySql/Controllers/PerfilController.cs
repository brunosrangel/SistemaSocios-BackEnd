using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class PerfilController : BaseController<perfilModel, IGenericService<perfilModel>>
    {
        private readonly IGenericService<perfilModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<perfilModel> _loger;
        public PerfilController(ITokenService tokenService, ILogger<perfilModel> loger,
                                  IGenericService<perfilModel> genericService) : base(genericService, loger)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(perfilModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

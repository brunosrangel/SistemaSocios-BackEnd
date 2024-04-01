using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    public class RedeSocialControlller : BaseController<RedeSocialModel, IGenericService<RedeSocialModel>>
    {
        private readonly IGenericService<RedeSocialModel> _genericService;
        private readonly ITokenService _tokenService;
        protected readonly ILogger<RedeSocialModel> _loger;
        public RedeSocialControlller(ITokenService tokenService, ILogger<RedeSocialModel> loger,
                                  IGenericService<RedeSocialModel> genericService) : base(genericService, loger, tokenService)
        {
            _genericService = genericService;
            _tokenService = tokenService;
            _loger = loger;
        }

        // Implementação do método abstrato para obter o ID da entidade

        protected override string GetEntityId(RedeSocialModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

using SistemaSocio.Service.interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SistemaSocios.Webapi.Controllers
{
    [SwaggerTag("Entidade")]
    public class EntidadeController : BaseController<EntidadeModel, IEntityService<EntidadeModel>>
    {
        public EntidadeController(IEntityService<EntidadeModel> entidadeService) : base(entidadeService)
        {
        }



        // Implementação do método abstrato para obter o ID da entidade
        protected override string GetEntityId(EntidadeModel entity)
        {
            return entity.Id.ToString();
        }
    }
}

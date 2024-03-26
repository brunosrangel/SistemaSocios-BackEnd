using SistemaSocio.Service.interfaces;
using SistemaSocios.Core.Model.Usuario;
using Swashbuckle.AspNetCore.Annotations;

namespace SistemaSocios.Webapi.Controllers
{
    [SwaggerTag("Usuários")]
    public class UsuarioController : BaseController<UsuarioModel, IEntityService<UsuarioModel>>
    {
        public UsuarioController(IEntityService<UsuarioModel> usuarioService) : base(usuarioService)
        {
        }

        // Implementação do método abstrato para obter o ID da entidade
        protected override string GetEntityId(UsuarioModel entity)
        {
            return entity.idUsuario;
        }
    }
}
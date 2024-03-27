using SistemaSocios.Core.Model.Usuario;

namespace SistemaSocio.Service.Services
{
    public interface IUserService<TEntity> where TEntity : IDocument
    {
        Task<UsuarioModel> EfetuaLogin(string usuario, string pass);
    }
}
using SistemaSocios.Core.Model.Usuario;

public interface IUsuarioService
{
    Task<List<UsuarioModel>> GetAllUsuarios();
    Task<UsuarioModel> GetUsuarioById(string id);
    Task AddUsuario(UsuarioModel entidade);
    Task<bool> UpdateUsuario(string id, UsuarioModel entidade);
    Task<bool> DeleteUsuario(string id);
}

using SistemaSocios.Core.Model.Usuario;

public interface IUsuarioService
{
    Task<List<UsuarioModel>> GetAllUsuarios();
    Task<UsuarioModel> GetUsuarioById(string id);
    Task AddUsuario(UsuarioModel usuario);
    Task<bool> UpdateUsuario(string id, UsuarioModel usuario);
    Task<bool> DeleteUsuario(string id);
}

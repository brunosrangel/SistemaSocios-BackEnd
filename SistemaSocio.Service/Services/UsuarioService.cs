using SistemaSocios.Core.Model.Usuario;

public class UsuarioService : IUsuarioService
{
    private readonly IRepository<UsuarioModel> _repository;

    public UsuarioService(IRepository<UsuarioModel> repository)
    {
        _repository = repository;
    }

    public async Task<List<UsuarioModel>> GetAllUsuarios()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<UsuarioModel> GetUsuarioById(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddUsuario(UsuarioModel entidade)
    {
        await _repository.AddAsync(entidade);
    }

    public async Task<bool> UpdateUsuario(string id, UsuarioModel entidade)
    {
        return await _repository.UpdateAsync(id, entidade);
    }

    public async Task<bool> DeleteUsuario(string id)
    {
        return await _repository.DeleteAsync(id);
    }
}

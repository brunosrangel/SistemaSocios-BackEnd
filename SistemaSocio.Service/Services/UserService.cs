using SistemaSocios.Core.Model.Usuario;

namespace SistemaSocio.Service.Services
{
    public class UserService<TEntity> : IUserService<TEntity> where TEntity : IDocument
    {
        private readonly IMongoRepository<TEntity> _repository;
        private readonly IUsuarioMongoRepository<UsuarioModel> _Urepository;

        public UserService(IMongoRepository<TEntity> repository, IUsuarioMongoRepository<UsuarioModel> Urepository)
        {
            _repository = repository;
            _Urepository = Urepository;
        }

        public async Task<UsuarioModel> EfetuaLogin(string usuario, string pass)
        {
            var ret = await _Urepository.GetToken(usuario, pass);
            return ret;
        }
    }
}

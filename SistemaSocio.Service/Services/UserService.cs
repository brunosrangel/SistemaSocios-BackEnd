using SistemaSocio.Service.interfaces;
using SistemaSocios.Core.Model.Usuario;
using SistemaSocios.Db.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

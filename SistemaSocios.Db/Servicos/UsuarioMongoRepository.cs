using MongoDB.Driver;
using SistemaSocios.Db.Model;


namespace SistemaSocios.Db.Servicos
{
    public class UsuarioMongoRepository<TEntity> : IUsuarioMongoRepository<TEntity> where TEntity 
        : IDocument, IUsuarioModel

    {
        private readonly IMongoCollection<TEntity> _collection;

        public UsuarioMongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TEntity>("Usuario");
        }


        public async Task<TEntity> GetToken(string user, string pass)
        {
            string data = "";
            TEntity dtUsuario = default;
            try
            {
                var filterUser = Builders<TEntity>.Filter.Eq("email", user);
                var userData = await _collection.Find(filterUser).FirstOrDefaultAsync();
                if (userData == null)
                {
                    data = "Usuário não encontrado";
                }
                else
                {
                    // Verifica a senha, substitua "password" pelo nome da propriedade correspondente em TEntity
                    if (userData.senha == pass)
                    {
                        dtUsuario = userData;
                    }
                    else
                    {
                        data = "Senha incorreta";
                    }
                }
            }
            catch (Exception ex)
            {
                // Trate a exceção adequadamente, por exemplo, registrando-a ou retornando uma mensagem de erro significativa
                throw new Exception("Erro ao buscar usuário: " + ex.Message, ex);
            }

            return dtUsuario;
        }


    }
}

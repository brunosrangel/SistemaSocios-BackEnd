namespace SistemaSocios.Db.Servicos
{
    public interface IUsuarioMongoRepository<TEntity> where TEntity : IDocument
    {
        Task<TEntity> GetToken(string user, string pass);
    }
}
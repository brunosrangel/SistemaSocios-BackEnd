using System.Linq.Expressions;

public interface IMongoRepository<TDocument> where TDocument : IDocument
{
    Task<TDocument> GetByIdAsync(string id);
    Task<List<TDocument>> GetAllAsync();
    Task<TDocument> InsertOneAsync(TDocument document);
    Task<bool> ReplaceOneAsync(TDocument document);
    Task<bool> DeleteByIdAsync(string id);
    Task<TDocument> GetToken(string user, string pass);
}

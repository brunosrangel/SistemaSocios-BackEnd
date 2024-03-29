using MongoDB.Driver;
using SistemaSocios.Db.MongoDb;

public class MongoRepository<TDocument> : IMongoRepository<TDocument>
    where TDocument : IDocument
{
    private readonly IMongoCollection<TDocument> _collection;

    public MongoRepository(IMongoDbSettings settings)
    {
        var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
    }

    public async Task<TDocument> GetByIdAsync(string id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id.ToString(), id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<TDocument>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<TDocument> InsertOneAsync(TDocument document)
    {
        await _collection.InsertOneAsync(document);
        return document;
    }

    public async Task<bool> ReplaceOneAsync(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
        var result = await _collection.ReplaceOneAsync(filter, document);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteByIdAsync(string id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id.ToString(), id);
        var result = await _collection.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    private string GetCollectionName(Type documentType)
    {
        var attributes = documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true);
        if (attributes.Length > 0)
        {
            return ((BsonCollectionAttribute)attributes[0]).CollectionName;
        }
        else
        {
            return null;
        }
    }

    public Task<TDocument> GetToken(string user, string pass)
    {
        throw new NotImplementedException();
    }
}
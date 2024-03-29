using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public interface IDocument<T>
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    T Id { get; set; }

    DateTime CreatedAt { get; }
}

public abstract class Document : IDocument<ObjectId>
{
    public ObjectId Id { get; set; }

    public DateTime CreatedAt => Id.CreationTime;
}

public abstract class DocModel : IDocument<Guid>, IDocModel
{
    public Guid Id { get; set; }

    // IDocument<Guid> implementation
    public DateTime CreatedAt => throw new NotImplementedException();
}

internal interface IDocModel
{
    Guid Id { get; set; }
}
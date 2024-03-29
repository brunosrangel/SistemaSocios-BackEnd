
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.MongoDb;

[BsonCollection("Entidade")]

public class EntidadeModelMongoDb : Document
{

    [BsonElement("descricaoentidade")]
    [BsonRequired]
    public string DescricaoEntidade { get; set; }

    [BsonElement("statusentidade")]
    [BsonRequired]
    public bool statusEntidade { get; set; }

}



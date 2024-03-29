using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Db.MongoDb
{
    [BsonCollection("Usuario")]
    public class ValorMensalidadeMongoDb : Document
    {
        [BsonElement("valormensalidade")]
        public decimal ValorMensalidade { get; set; }
    }
}

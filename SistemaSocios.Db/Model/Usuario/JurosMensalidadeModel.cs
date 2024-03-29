using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Db.MongoDb.Usuario
{
    [BsonCollection("Usuario")]
    public class JurosMensalidadeMongoDb : Document
    {

        [BsonElement("valorjuros")]
        public int valorJuros { get; set; }
    }
}

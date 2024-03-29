using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Db.MongoDb.Usuario
{
    [BsonCollection("Usuario")]
    public class TipoEnderecoUsuarioMongoDb : Document
    {

        [BsonElement("descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}

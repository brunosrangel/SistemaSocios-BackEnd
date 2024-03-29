using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Db.MongoDb.Usuario
{
    [BsonCollection("Usuario")]
    public class TelefoneUsuarioMongoDb : Document
    {
        [BsonElement("dddtelefoneusuario")]
        public string DddTelefoneUsuario { get; set; }

        [BsonElement("numerotelefoneusuario")]
        public string NumeroTelefoneUsuario { get; set; }

        [BsonElement("tipotelefone")]
        public TipoTelefoneUsuarioMongoDb TipoTelefone { get; set; }
    }
}

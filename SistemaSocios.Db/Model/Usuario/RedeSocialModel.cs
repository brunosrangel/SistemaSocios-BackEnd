using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Db.MongoDb.Usuario
{
    [BsonCollection("Usuario")]
    public class RedeSocialMongoDb : Document
    {

        [BsonElement("descricaoredesocialusuario")]
        public string DescricaoRedeSocialUsuario { get; set; }

        [BsonElement("urlredesocial")]
        public string UrlRedeSocial { get; set; }

        [BsonElement("isactive")]
        public bool IsActive { get; set; }
    }
}

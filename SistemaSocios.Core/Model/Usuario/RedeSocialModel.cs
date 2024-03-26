using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Core.Model.Usuario
{
    public class RedeSocialModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdRedeSocialUsuario { get; set; }

        [BsonElement("descricaoredesocialusuario")]
        public string DescricaoRedeSocialUsuario { get; set; }

        [BsonElement("urlredesocial")]
        public string UrlRedeSocial { get; set; }

        [BsonElement("isactive")]
        public bool IsActive { get; set; }
    }
}

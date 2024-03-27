using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class RedeSocialModel : Document
    {

        [BsonElement("descricaoredesocialusuario")]
        public string DescricaoRedeSocialUsuario { get; set; }

        [BsonElement("urlredesocial")]
        public string UrlRedeSocial { get; set; }

        [BsonElement("isactive")]
        public bool IsActive { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Core.Model.Usuario
{
    public class TelefoneUsuarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdTelefoneUsuario { get; set; }

        [BsonElement("dddtelefoneusuario")]
        public string DddTelefoneUsuario { get; set; }

        [BsonElement("numerotelefoneusuario")]
        public string NumeroTelefoneUsuario { get; set; }

        [BsonElement("tipotelefone")]
        public TipoTelefoneUsuarioModel TipoTelefone { get; set; }
    }
}

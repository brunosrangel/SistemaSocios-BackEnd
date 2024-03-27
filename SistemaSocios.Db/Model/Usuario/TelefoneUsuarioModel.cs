using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class TelefoneUsuarioModel : Document
    {
        [BsonElement("dddtelefoneusuario")]
        public string DddTelefoneUsuario { get; set; }

        [BsonElement("numerotelefoneusuario")]
        public string NumeroTelefoneUsuario { get; set; }

        [BsonElement("tipotelefone")]
        public TipoTelefoneUsuarioModel TipoTelefone { get; set; }
    }
}

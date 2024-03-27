using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class TipoEnderecoUsuarioModel : Document
    {

        [BsonElement("descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}

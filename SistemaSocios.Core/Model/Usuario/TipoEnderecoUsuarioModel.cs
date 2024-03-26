using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Core.Model.Usuario
{
    public class TipoEnderecoUsuarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdTipoEndereco { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}

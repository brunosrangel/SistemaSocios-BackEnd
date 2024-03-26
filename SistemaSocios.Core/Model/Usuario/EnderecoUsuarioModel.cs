using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Core.Model.Usuario;

namespace SistemaSocios.Core.Model
{
    public class EnderecoUsuarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdEnderecoUsuario { get; set; }

        [BsonElement("endereco")]
        public string endereco { get; set; }

        [BsonElement("cidade")]
        public string cidade { get; set; }

        [BsonElement("estado")]
        public string estado { get; set; }

        [BsonElement("tipoendereco")]
        public TipoEnderecoUsuarioModel TipoEndereco { get; set; }

        [BsonElement("cep")]
        public string Cep { get; set; }
    }
}

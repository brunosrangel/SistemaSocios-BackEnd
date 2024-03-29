using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.MongoDb.Usuario;

namespace SistemaSocios.Db.MongoDb
{
    [BsonCollection("Usuario")]
    public class EnderecoUsuarioMongoDb : Document
    {
        [BsonElement("endereco")]
        public string endereco { get; set; }

        [BsonElement("cidade")]
        public string cidade { get; set; }

        [BsonElement("estado")]
        public string estado { get; set; }

        [BsonElement("tipoendereco")]
        public TipoEnderecoUsuarioMongoDb TipoEndereco { get; set; }

        [BsonElement("cep")]
        public string Cep { get; set; }
    }
}

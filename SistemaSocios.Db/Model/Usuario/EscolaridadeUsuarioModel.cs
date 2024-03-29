using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Db.MongoDb.Usuario
{
    [BsonCollection("Usuario")]
    public class EscolaridadeUsuarioMongoDb : Document
    {

        [BsonElement("descricaoescolaridade")]
        public string DescricaoEscolaridade { get; set; }


        [BsonElement("statusescolaridade")]
        public bool StatusEscolaridade { get; set; }
    }
}

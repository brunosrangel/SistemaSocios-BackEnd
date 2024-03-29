using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Db.MongoDb.perfilAcesso
{
    [BsonCollection("PerfilAcesso")]
    public class perfilMongoDb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPerfil { get; set; }

        [BsonElement("descricaoperfil")]
        public string DescricaoPerfil { get; set; }

        [BsonElement("statusperfil")]
        public bool StatusPerfil { get; set; } = true;
    }
}

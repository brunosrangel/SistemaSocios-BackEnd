using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.perfilAcesso
{
    [BsonCollection("PerfilAcesso")]
    public class perfilModel
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

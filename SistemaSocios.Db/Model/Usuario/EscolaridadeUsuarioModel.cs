using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class EscolaridadeUsuarioModel : Document
    {

        [BsonElement("descricaoescolaridade")]
        public string DescricaoEscolaridade { get; set; }


        [BsonElement("statusescolaridade")]
        public bool StatusEscolaridade { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model
{
    [BsonCollection("Usuario")]
    public class ValorMensalidadeModel : Document
    {
        [BsonElement("valormensalidade")]
        public decimal ValorMensalidade { get; set; }
    }
}

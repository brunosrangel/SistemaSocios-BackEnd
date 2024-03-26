using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Core.Model
{
    public class ValorMensalidadeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdValorMensalidade { get; set; }

        [BsonElement("valormensalidade")]
        public decimal ValorMensalidade { get; private set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaSocios.Core.Model.Usuario
{
    public class JurosMensalidadeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdJurosMensalidadeUsuario { get; set; }

        [BsonElement("valorjuros")]
        public int valorJuros { get; set; }
    }
}

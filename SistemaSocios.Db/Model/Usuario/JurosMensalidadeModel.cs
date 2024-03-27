using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class JurosMensalidadeModel : Document
    {

        [BsonElement("valorjuros")]
        public int valorJuros { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Core.Model.perfilAcesso
{
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

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Core.Model.Usuario
{
    public class EscolaridadeUsuarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdEscolaridade { get; set; }

        [BsonElement("descricaoescolaridade")]
        public string DescricaoEscolaridade { get; set; }


        [BsonElement("statusescolaridade")]
        public bool StatusEscolaridade { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;
using System.Text.Json.Serialization;


namespace SistemaSocios.Core.Model.Entidade
{
    [BsonCollection("Entidade")]

    public class EntidadeModel : Document
    {

        [BsonElement("descricaoentidade")]
        [BsonRequired]
        public string DescricaoEntidade { get; set; }

        [BsonElement("statusentidade")]
        [BsonRequired]
        public bool statusEntidade { get; set; }

    }

    }


﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.perfilAcesso
{
    [BsonCollection("PerfilAcesso")]
    public class perfilModel : DocModel
    {
         
        public string DescricaoPerfil { get; set; }
        public bool StatusPerfil { get; set; } = true;
    }
}

﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model
{
    public class ValorMensalidadeModel : DocModel
    {
  
        public decimal ValorMensalidade { get; set; }
    }
}

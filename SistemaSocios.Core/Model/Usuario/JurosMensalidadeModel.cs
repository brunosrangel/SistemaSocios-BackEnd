﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    public class JurosMensalidadeModel : Document
    {
        public int valorJuros { get; set; }
    }
}

﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Core.Model.Usuario;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model
{
    public class EnderecoUsuarioModel : Document
    {
        public string endereco { get; set; }

        public string cidade { get; set; }
        public string estado { get; set; }
        public TipoEnderecoUsuarioModel TipoEndereco { get; set; }

        public string Cep { get; set; }
    }
}

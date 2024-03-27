﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;
using System.Text.Json.Serialization;


namespace SistemaSocios.Core.Model.Entidade
{

    public class EntidadeModel : DocModel
    {


        public string DescricaoEntidade { get; set; }
        public bool statusEntidade { get; set; }

    }

}


﻿using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class TipoTelefoneUsuarioModel : DocModel
    {
        public string Descricao { get; set; } = string.Empty;

    }
}

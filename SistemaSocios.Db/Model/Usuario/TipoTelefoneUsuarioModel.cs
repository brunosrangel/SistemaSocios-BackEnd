using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class TipoTelefoneUsuarioModel : Document
    {
        public string Descricao { get; set; } = string.Empty;

    }
}

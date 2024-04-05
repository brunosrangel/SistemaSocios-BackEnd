using System.ComponentModel.DataAnnotations.Schema;

[Table("TipoTelefoneUsuario")]

public class TipoTelefoneUsuarioModel : DocModel
{
    public string Descricao { get; set; } = string.Empty;

}


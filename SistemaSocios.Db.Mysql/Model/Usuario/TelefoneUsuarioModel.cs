using System.ComponentModel.DataAnnotations.Schema;

[Table("TelefoneUsuario")]
public class TelefoneUsuarioModel : DocModel
{
    public string DddTelefoneUsuario { get; set; }

    public string NumeroTelefoneUsuario { get; set; }
    public TipoTelefoneUsuarioModel TipoTelefone { get; set; }
}


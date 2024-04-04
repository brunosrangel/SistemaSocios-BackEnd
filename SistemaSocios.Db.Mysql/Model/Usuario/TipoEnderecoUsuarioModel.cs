using System.ComponentModel.DataAnnotations.Schema;

[Table("TipoEnderecoUsuario")]
public class TipoEnderecoUsuarioModel : DocModel
{

    public string Descricao { get; set; } = string.Empty;

}
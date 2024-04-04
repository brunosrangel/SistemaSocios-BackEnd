using System.ComponentModel.DataAnnotations.Schema;

[Table("EscolaridadeUsuario")]
public class EscolaridadeUsuarioModel : DocModel
{
    public string DescricaoEscolaridade { get; set; }
    public bool StatusEscolaridade { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

[Table("perfil")]
public class perfilModel : DocModel
{
    public string DescricaoPerfil { get; set; }
}


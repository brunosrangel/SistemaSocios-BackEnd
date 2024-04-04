using System.ComponentModel.DataAnnotations.Schema;

[Table("RedeSocial")]
public class RedeSocialModel : DocModel
{
    public string DescricaoRedeSocialUsuario { get; set; }
    public string Descricao { get; set; }
    public string UrlRedeSocial { get; set; }
    public bool IsActive { get; set; }
}
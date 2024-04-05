using System.ComponentModel.DataAnnotations.Schema;

[Table("RedeSocial")]
public class RedeSocialModel : DocModel
{
    public string DescricaoRedeSocialUsuario { get; set; }
    public string Descricao { get; set; }
    public string UrlRedeSocial { get; set; }

    // Chave estrangeira para UsuarioModel
    public Guid UsuarioID { get; set; } 

    //Propriedade para navegação

    public virtual UsuarioModel UsuarioModel { get; set; }
    public virtual List<RedeSocialModel> RedesSociais { get; set; }
}
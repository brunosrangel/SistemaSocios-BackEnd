using System.ComponentModel.DataAnnotations.Schema;

[Table("TelefoneUsuario")]
public class TelefoneUsuarioModel : DocModel
{

    public string DddTelefoneUsuario { get; set; }
    public string NumeroTelefoneUsuario { get; set; }

    // Chave estrangeira
    public Guid UsuarioID { get; set; }
    public Guid TipoTelefoneUsuarioId { get; set; } 

    // Propriedade de navegação
    public virtual TipoTelefoneUsuarioModel TipoTelefone { get; set; }
    public virtual UsuarioModel Usuario { get; set; } 
    public virtual List<TelefoneUsuarioModel> Telefones { get; set; } 


}


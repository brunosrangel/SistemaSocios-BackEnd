using System.ComponentModel.DataAnnotations.Schema;

[Table("EnderecoUsuario")]
public class EnderecoUsuarioModel : DocModel
{
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }

    // Propriedade de navegação
    public virtual List<EnderecoUsuarioModel> Enderecos { get; set; }
    public virtual UsuarioModel Usuario { get; set; }
    public virtual TipoEnderecoUsuarioModel TipoEndereco { get; set; }

    // Chave estrangeira para TipoEnderecoUsuarioModel
    public Guid TipoEnderecoUsuarioId { get; set; }
    public Guid UsuarioID { get; set; }

}

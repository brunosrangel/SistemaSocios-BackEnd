public class EnderecoUsuarioModel : DocModel
{
    public string endereco { get; set; }
    public string cidade { get; set; }
    public string estado { get; set; }
    public Guid TipoEnderecoUsuarioId { get; set; } // Chave estrangeira para TipoEnderecoUsuarioModel
    public TipoEnderecoUsuarioModel TipoEndereco { get; set; }
    public string Cep { get; set; }
}
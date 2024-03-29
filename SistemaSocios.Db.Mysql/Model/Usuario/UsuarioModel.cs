public class UsuarioModel : DocModel
{
    public string nomeUsuario { get; set; }
    public string email { get; set; }
    public string senha { get; set; }
    public Guid enderecoId { get; set; } // Chave estrangeira para EnderecoUsuarioModel
    public List<EnderecoUsuarioModel> endereco { get; set; }
    public Guid telefoneId { get; set; } // Chave estrangeira para TelefoneUsuarioModel
    public List<TelefoneUsuarioModel> telefone { get; set; }
    public string profissao { get; set; }
    public Guid EscolaridadId { get; set; } // Chave estrangeira para EscolaridadeUsuarioModel
    public EscolaridadeUsuarioModel escolaridade { get; set; }
    public Guid RedeSocialId { get; set; } // Chave estrangeira para RedeSocialModel
    public List<RedeSocialModel> redesocial { get; set; }
    public DateTime dataEntrada { get; set; }
    public DateTime dataIniciacao { get; set; }
    public DateTime dataUltimaObrigacao { get; set; }
    public Guid JurosMensalidadeId { get; set; } // Chave estrangeira para JurosMensalidadeModel
    public List<JurosMensalidadeModel> aplicaJurosMensalidade { get; set; }
    public Guid ValorMensalidadeId { get; set; } // Chave estrangeira para JurosMensalidadeModel
    public List<ValorMensalidadeModel> Mensalidade { get; set; }
    public Guid EntidadeId { get; set; } // Chave estrangeira para EntidadeModel
    public List<EntidadeModel> entidade { get; set; }
    public Guid perfilId { get; set; } // Chave estrangeira para perfilModel
    public perfilModel perfilAcesso { get; set; }
}
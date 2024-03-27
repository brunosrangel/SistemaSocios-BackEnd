namespace SistemaSocios.Db.Servicos
{
    public interface IUsuarioModel
    {
        
            public string nomeUsuario { get; set; }
            public string email { get; set; }
            public string senha { get; set; }
           // public EnderecoUsuarioModel endereco { get; set; }
            //public TelefoneUsuarioModel telefone { get; set; }
            public string profissao { get; set; }
            //public EscolaridadeUsuarioModel escolaridade { get; set; }
            //public RedeSocialModel redesocial { get; set; }
            public DateTime dataEntrada { get; set; }
            public DateTime dataIniciacao { get; set; }
            public DateTime dataUltimaObrigacao { get; set; }
            //public JurosMensalidadeModel aplicaJurosMensalidade { get; set; }
            //public ValorMensalidadeModel Mensalidade { get; set; }
            //public EntidadeModel entidade { get; set; }
            //public perfilModel perfilAcesso { get; set; }
        }
    }

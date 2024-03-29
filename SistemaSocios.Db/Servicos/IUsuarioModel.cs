namespace SistemaSocios.Db.Servicos
{
    public interface IUsuarioMongoDb
    {

        public string nomeUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        // public EnderecoUsuarioMongoDb endereco { get; set; }
        //public TelefoneUsuarioMongoDb telefone { get; set; }
        public string profissao { get; set; }
        //public EscolaridadeUsuarioMongoDb escolaridade { get; set; }
        //public RedeSocialMongoDb redesocial { get; set; }
        public DateTime dataEntrada { get; set; }
        public DateTime dataIniciacao { get; set; }
        public DateTime dataUltimaObrigacao { get; set; }
        //public JurosMensalidadeMongoDb aplicaJurosMensalidade { get; set; }
        //public ValorMensalidadeMongoDb Mensalidade { get; set; }
        //public EntidadeMongoDb entidade { get; set; }
        //public perfilMongoDb perfilAcesso { get; set; }
    }
}

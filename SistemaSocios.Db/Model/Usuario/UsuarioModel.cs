using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Core.Model.Entidade;
using SistemaSocios.Core.Model.perfilAcesso;
using SistemaSocios.Db.Model;
using SistemaSocios.Db.Servicos;

namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class UsuarioModel : Document, IUsuarioModel
    {
        [BsonElement("nomeusuario")]
        [BsonRequired]
        public string nomeUsuario { get; set; }

        [BsonElement("email")]
        [BsonRequired]
        public string email { get; set; }

        [BsonElement("senha")]
        public string senha { get; set; }

        [BsonElement("endereco")]
        public EnderecoUsuarioModel endereco { get; set; }

        [BsonElement("telefone")]
        public TelefoneUsuarioModel telefone { get; set; }

        [BsonElement("profissao")]
        public string profissao { get; set; }

        [BsonElement("escolaridade")]
        public EscolaridadeUsuarioModel escolaridade { get; set; }

        [BsonElement("redesocial")]
        public RedeSocialModel redesocial { get; set; }

        [BsonElement("dataentrada")]
        public DateTime dataEntrada { get; set; }

        [BsonElement("datainiciacao")]
        public DateTime dataIniciacao { get; set; }

        [BsonElement("dataultimaobrigacao")]
        public DateTime dataUltimaObrigacao { get; set; }

        [BsonElement("aplicajurosmensalidade")]
        public JurosMensalidadeModel aplicaJurosMensalidade { get; set; }

        [BsonElement("mensalidade")]
        public ValorMensalidadeModel Mensalidade { get; set; }

        //[BsonElement("entidade")]
        //public EntidadeModel entidade { get; set; }
        [BsonElement("entidadeId")]
        public ObjectId EntidadeId { get; set; }

        //[BsonElement("perfil")]
        //public perfilModel perfilAcesso { get; set; }



    }
    
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Servicos;

namespace SistemaSocios.Db.MongoDb.Usuario
{
    [BsonCollection("Usuario")]
    public class UsuarioModelMongoDb : Document, IUsuarioMongoDb
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
        public EnderecoUsuarioMongoDb endereco { get; set; }

        [BsonElement("telefone")]
        public TelefoneUsuarioMongoDb telefone { get; set; }

        [BsonElement("profissao")]
        public string profissao { get; set; }

        [BsonElement("escolaridade")]
        public EscolaridadeUsuarioMongoDb escolaridade { get; set; }

        [BsonElement("redesocial")]
        public RedeSocialMongoDb redesocial { get; set; }

        [BsonElement("dataentrada")]
        public DateTime dataEntrada { get; set; }

        [BsonElement("datainiciacao")]
        public DateTime dataIniciacao { get; set; }

        [BsonElement("dataultimaobrigacao")]
        public DateTime dataUltimaObrigacao { get; set; }

        [BsonElement("aplicajurosmensalidade")]
        public JurosMensalidadeMongoDb aplicaJurosMensalidade { get; set; }

        [BsonElement("mensalidade")]
        public ValorMensalidadeMongoDb Mensalidade { get; set; }

        //[BsonElement("entidade")]
        //public EntidadeMongoDb entidade { get; set; }
        [BsonElement("entidadeId")]
        public ObjectId EntidadeId { get; set; }

        //[BsonElement("perfil")]
        //public perfilMongoDb perfilAcesso { get; set; }



    }

}

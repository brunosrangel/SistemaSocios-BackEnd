namespace SistemaSocios.Db.MongoDb.Usuario
{
    [BsonCollection("Usuario")]
    public class TipoTelefoneUsuarioMongoDb : Document
    {
        public string Descricao { get; set; } = string.Empty;

    }
}

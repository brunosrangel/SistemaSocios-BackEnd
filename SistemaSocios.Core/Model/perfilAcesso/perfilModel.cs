namespace SistemaSocios.Core.Model.perfilAcesso
{
    [Db.MongoDb.BsonCollection("PerfilAcesso")]
    public class perfilModel : DocModel
    {
        public string DescricaoPerfil { get; set; }
        public bool StatusPerfil { get; set; } = true;
    }
}
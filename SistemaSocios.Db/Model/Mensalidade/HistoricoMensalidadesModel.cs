using SistemaSocios.Db.MongoDb.Usuario;

public class HistoricoMensalidadesMongoDb : Document
{
    public UsuarioModelMongoDb Usuario { get; set; }
    public int MesReferencia { get; set; }
    public int AnoReferencia { get; set; }
    public StatusMensalidadeMongoDb statusMensalidade { get; set; }

}

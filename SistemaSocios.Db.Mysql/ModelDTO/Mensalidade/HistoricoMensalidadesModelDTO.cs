public class HistoricoMensalidadesModelDTO : DocModel
{
    public Guid UsuarioID { get; set; } // Chave estrangeira para UsuarioModel
    public UsuarioModel Usuario { get; set; }
    public int MesReferencia { get; set; }
    public int AnoReferencia { get; set; }
    public Guid StatusMensalidadeId { get; set; } // Chave estrangeira para StatusMensalidadeModel
    public StatusMensalidadeModel statusMensalidade { get; set; }

}

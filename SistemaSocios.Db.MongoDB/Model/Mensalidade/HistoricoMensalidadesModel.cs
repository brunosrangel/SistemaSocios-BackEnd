using System.ComponentModel.DataAnnotations.Schema;

[Table("HistoricoMensalidades")]
public class HistoricoMensalidadesModel : DocModel
{
    public int MesReferencia { get; set; }
    public int AnoReferencia { get; set; }

    // Propriedade de navegação
    public virtual List<StatusMensalidadeModel> StatusMensalidades { get; set; }
    public virtual UsuarioModel Usuario { get; set; }
    public virtual List<HistoricoMensalidadesModel> HistoricosMensalidades { get; set; }

    // Chave estrangeira para StatusMensalidadeModel
    public Guid StatusMensalidadeId { get; set; } 
    public Guid UsuarioID { get; set; } 
}

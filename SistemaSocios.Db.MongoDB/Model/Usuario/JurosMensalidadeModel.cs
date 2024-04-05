using System.ComponentModel.DataAnnotations.Schema;

[Table("JurosMensalidade")]
public class JurosMensalidadeModel : DocModel
{
    public int valorJuros { get; set; }
    public DateTime? DataVigenciaJuros { get; set; }
    public bool statusValorJuros { get; set; }

    // Chave estrangeira para UsuarioModel
    public Guid UsuarioID { get; set; }
    // Propriedade de navegação
    public virtual UsuarioModel UsuarioModel { get; set; }
    public virtual List<JurosMensalidadeModel> JurosMensalidadesModel { get; set; }

}
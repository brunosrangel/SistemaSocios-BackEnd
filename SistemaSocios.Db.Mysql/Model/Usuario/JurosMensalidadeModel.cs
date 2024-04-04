using System.ComponentModel.DataAnnotations.Schema;

[Table("JurosMensalidade")]
public class JurosMensalidadeModel : DocModel
{
    public int valorJuros { get; set; }
    public DateTime? DataVigenciaJuros { get; set; }
    public bool statusValorJuros { get; set; }
}
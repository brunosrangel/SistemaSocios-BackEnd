using System.ComponentModel.DataAnnotations.Schema;

[Table("StatusMensalidade")]
public class StatusMensalidadeModel : DocModel
{
    public string DescricaoStatus { get; set; }
}


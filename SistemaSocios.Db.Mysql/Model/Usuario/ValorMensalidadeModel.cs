using System.ComponentModel.DataAnnotations.Schema;

[Table("ValorMensalidade")]

public class ValorMensalidadeModel : DocModel
{

    public decimal ValorMensalidade { get; set; }
    public DateTime VigenciaMensalidade { get; set; }
    public bool statusValorMensalidade { get; set; }
}

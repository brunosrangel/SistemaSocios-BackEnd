using System.ComponentModel.DataAnnotations.Schema;

[Table("ValorMensalidade")]

public class ValorMensalidadeModel : DocModel
{
    public decimal ValorMensalidade { get; set; }
    public DateTime VigenciaMensalidade { get; set; }
    public bool statusValorMensalidade { get; set; }


    // Propriedade de navegação
    public virtual UsuarioModel UsuarioModel { get; set; }
    public virtual List<ValorMensalidadeModel> ValorMensalidades { get; set; }

    // Chave estrangeira para UsuarioModel
    public Guid UsuarioID { get; set; }
}

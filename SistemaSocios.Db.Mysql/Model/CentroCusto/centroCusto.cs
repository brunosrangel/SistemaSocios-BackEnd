public class CentroCusto : DocModel
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public virtual EntidadeModel EntidadeModel { get; set; }

}
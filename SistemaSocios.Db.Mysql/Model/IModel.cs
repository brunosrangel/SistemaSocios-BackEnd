
public abstract class DocModel : IDocModel
{
    public Guid Id { get; set; }
    public TipoStatus status { get; set; }
}

internal interface IDocModel
{
    Guid Id { get; set; }
    public TipoStatus status { get; set; }

}

public enum TipoStatus 
{
    Ativo= 1,
    Inativo= 0,

}
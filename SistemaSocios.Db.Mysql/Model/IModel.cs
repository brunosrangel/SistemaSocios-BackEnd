
public abstract class DocModel : IDocModel
{
    public Guid Id { get; set; }
}

internal interface IDocModel
{
    Guid Id { get; set; }
}

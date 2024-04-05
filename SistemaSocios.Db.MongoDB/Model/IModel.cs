
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public abstract class DocModel : IDocModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool? status { get; set; } = true;
}


internal interface IDocModel
{
    Guid Id { get; set; }
    public bool? status { get; set; } 
}

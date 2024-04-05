using System.ComponentModel.DataAnnotations.Schema;

[Table("Entidade")]
public class EntidadeModel : DocModel
{
    public string DescricaoEntidade { get; set; }

}


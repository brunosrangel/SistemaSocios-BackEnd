namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class EscolaridadeUsuarioModel : DocModel
    {

        public string DescricaoEscolaridade { get; set; }


        public bool StatusEscolaridade { get; set; }
    }
}

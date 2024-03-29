namespace SistemaSocios.Core.Model.Usuario
{
    [BsonCollection("Usuario")]
    public class RedeSocialModel : DocModel
    {

        public string DescricaoRedeSocialUsuario { get; set; }


        public string UrlRedeSocial { get; set; }

        public bool IsActive { get; set; }
    }
}

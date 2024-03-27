using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SistemaSocios.Db.Model;

namespace SistemaSocios.Core.Model.Usuario
{
    public class TipoEnderecoUsuarioModel : DocModel
    {

         public string Descricao { get; set; } = string.Empty;
    }
}

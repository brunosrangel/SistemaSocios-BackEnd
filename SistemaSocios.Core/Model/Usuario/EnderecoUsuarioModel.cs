using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Core.Model.Usuario
{
    public class EnderecoUsuarioModel
    {
        public string IdEnderecoUsuario { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public TipoEnderecoUsuarioModel TipoEndereco { get; set; }
        public string Cep { get; set; }



    }
}

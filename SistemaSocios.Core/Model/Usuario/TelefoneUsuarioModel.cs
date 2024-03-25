using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Core.Model.Usuario
{
    public class TelefoneUsuarioModel
    {
        public string IdTelefoneUsuario { get; set; }
        public string DddTelefoneUsuario { get; set; }
        public string NumeroTelefoneUsuario { get; set; }
        public TipoTelefoneUsuarioModel TipoTelefone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Core.Model.Usuario
{
    public class RedeSocialModel
    {
        public string IdRedeSocialUsuario { get; set; }
        public string DescricaoRedeSocialUsuario { get; set; }
        public string UrlRedeSocial { get; set; }
        public bool IsActive { get; set; }
    }
}

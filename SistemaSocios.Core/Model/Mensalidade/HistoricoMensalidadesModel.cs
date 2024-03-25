using SistemaSocios.Core.Model.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Core.Model.Mensalidade
{
    public class HistoricoMensalidadesModel
    {
        public string IdMensalidade { get; set; }
        public UsuarioModel Usuario { get; set; }
        public int MesReferencia { get; set; }
        public int AnoReferencia { get; set; }
        public StatusMensalidadeModel statusMensalidade { get; set; }
 
    }
}

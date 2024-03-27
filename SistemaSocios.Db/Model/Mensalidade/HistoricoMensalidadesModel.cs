

using SistemaSocios.Core.Model.Usuario;

namespace SistemaSocios.Core.Model.Mensalidade
{
    public class HistoricoMensalidadesModel : Document
    {
        public UsuarioModel Usuario { get; set; }
        public int MesReferencia { get; set; }
        public int AnoReferencia { get; set; }
        public StatusMensalidadeModel statusMensalidade { get; set; }

    }
}

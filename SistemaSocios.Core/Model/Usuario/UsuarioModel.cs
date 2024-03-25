using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Core.Model.Usuario
{
    public class UsuarioModel
    {
        public string idUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string email { get; set; }
        public EnderecoUsuarioModel Endereco { get; set; }
        public TelefoneUsuarioModel Telefone { get; set; }
        public string Profissao { get; set; }
        public EscolaridadeUsuarioModel Escolaridade { get; set; }
        public RedeSocialModel RedeSocial { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataIniciacao { get; set; }
        public DateTime DataUltimaObrigacao { get; set; }
        public JurosMensalidadeModel AplicaJurosMensalidade { get; set; }
        public ValorMensalidadeModel ValorMensalidade { get; set; }


    }
}

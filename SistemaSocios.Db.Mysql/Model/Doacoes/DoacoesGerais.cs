using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Db.Mysql.Model.Doacoes
{
    public class DoacoesGerais : DocModel
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public virtual UsuarioModel UsuarioId { get; set; }


    }
}

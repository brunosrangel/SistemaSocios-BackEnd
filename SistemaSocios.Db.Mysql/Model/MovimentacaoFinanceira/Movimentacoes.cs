using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Db.Mysql.Model.MovimentacaoFinanceira
{
    public class Movimentacoes : DocModel
    {
        public TipoMovimentacao TipoMovimentacao { get; set; } 
        public DateTime Data {  get; set; }
        public decimal Valor { get; set; }
        public string ValorDescricao { get; set; }
        public virtual CentroCusto CentroCusto { get; set; }
    }

    public enum TipoMovimentacao
    {
        Entrada,
        Saida
    }

}

namespace SistemaSocios.Db.Mysql.Model.Eventos
{
    public class Eventos : DocModel
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Descicao { get; set; }
    }
}
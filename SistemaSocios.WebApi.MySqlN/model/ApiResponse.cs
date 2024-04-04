using System.Net;

namespace SistemaSocios.WebApi.MySqlN.model
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }  

    }

}

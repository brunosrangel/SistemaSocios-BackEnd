namespace SistemaSocios.WebApi.MySql.ControleSenha
{
    public class ControleSenha
    {
        public string HashPassword(string password)
        {
            // Gere um salt aleatório
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash da senha com o salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            // Salve hashedPassword e salt no banco de dados
            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Verifique se a senha corresponde ao hash
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}

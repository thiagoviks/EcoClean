namespace EcoClean.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // Em produção, nunca armazene senhas em texto claro.
        public string? Role { get; set; }
    }
}

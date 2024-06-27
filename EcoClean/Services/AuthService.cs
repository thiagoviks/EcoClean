using EcoClean.Models;

namespace EcoClean.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { UserId = 1, Username = "operador01", Password = "pass123", Role = "operador" },
                    new UserModel { UserId = 2, Username = "analista01", Password = "pass123", Role = "analista" },
                    new UserModel { UserId = 3, Username = "gerente01", Password = "pass123", Role = "gerente" },
                    new UserModel { UserId = 4, Username = "operador02", Password = "pass123", Role = "operador" },
                    new UserModel { UserId = 5, Username = "analista02", Password = "pass123", Role = "analista" },
                    new UserModel { UserId = 6, Username = "gerente02", Password = "pass123", Role = "gerente" },
                    new UserModel { UserId = 7, Username = "operador03", Password = "pass123", Role = "operador" }
                };


        public UserModel Authenticate(string username, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

    }
}

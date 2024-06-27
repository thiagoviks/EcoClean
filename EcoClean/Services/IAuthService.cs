using EcoClean.Models;

namespace EcoClean.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }
}

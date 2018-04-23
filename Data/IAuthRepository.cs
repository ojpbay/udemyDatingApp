using System.Threading.Tasks;
using udemyDatingApp.Models;

namespace udemyDatingApp.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
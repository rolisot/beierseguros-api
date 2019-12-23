using System.Threading.Tasks;
using BeierSeguros.Domain.Users.Entities;
using BeierSeguros.Shared.Repositories;

namespace BeierSeguros.Domain.Users.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Authenticate(string email, string password);

        Task<bool> ExistsByEmail(string email);
    }
}
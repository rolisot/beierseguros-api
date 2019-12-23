using System;
using System.Threading.Tasks;
using BeierSeguros.Domain.Core;
using BeierSeguros.Domain.Users.Entities;
using BeierSeguros.Domain.Users.Repositories;
using BeierSeguros.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await this.GetByWhere(x =>
                               x.Email.Equals(email, System.StringComparison.InvariantCultureIgnoreCase))
                            .FirstOrDefaultAsync();

            if (user == null)
                return null;

            return PasswordHasher.IsValid(password, user.Password) ? user : null;
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            var entity = await this.GetByWhere(x => x.Email.Equals(email, System.StringComparison.InvariantCultureIgnoreCase))
                                    .FirstOrDefaultAsync();

            return entity != null;
        }
    }
}
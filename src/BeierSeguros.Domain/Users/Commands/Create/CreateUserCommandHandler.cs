using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Domain.Users.Entities;
using BeierSeguros.Domain.Users.Repositories;
using BeierSeguros.Shared.Notifications;
using MediatR;

namespace BeierSeguros.Domain.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Notifiable>
    {

        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notifiable> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsByEmail(request.Email);

            if (exists)
            {
                return new Notifiable(new NotifiableError($"O e-mail '{request.Email}' já está cadastrado"));
            }

            var newUser = new User(request.Name, request.Password, request.Email);
            await _repository.Add(newUser);
            await _repository.Save();
            return new Notifiable("Usuário cadastrado com sucesso", newUser);
        }
    }
}
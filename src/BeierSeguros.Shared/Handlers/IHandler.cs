using System.Threading.Tasks;
using BeierSeguros.Shared.Commands;
using BeierSeguros.Shared.Contracts;

namespace BeierSeguros.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T request);
    }
}
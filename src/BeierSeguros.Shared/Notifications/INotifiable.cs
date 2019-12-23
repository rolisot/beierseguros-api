using System.Collections.Generic;

namespace BeierSeguros.Shared.Notifications
{
    public interface INotifiable
    {
        string Message { get; }

        object Data { get; }

        IList<NotifiableError> Errors { get; }

        bool HasErrors { get; }
    }
}
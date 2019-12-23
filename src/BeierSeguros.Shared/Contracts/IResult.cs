using System.Collections.Generic;

namespace BeierSeguros.Shared.Contracts
{
    public interface IResult
    {
        object Data { get; }

        bool HasErrors { get; }

        bool Success { get; }

        string Message { get; }

        IEnumerable<string> Errors { get; }
    }
}
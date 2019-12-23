using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BeierSeguros.Shared.Contracts
{
    public class Result : IResult
    {
        private readonly IList<string> _messages = new List<string>();

        public Result()
        {
            Errors = new ReadOnlyCollection<string>(_messages);
        }

        public Result(object data)
        {
            Errors = new ReadOnlyCollection<string>(_messages);
            Data = data;
        }

        public Result(string message, object data)
        {
            Errors = new ReadOnlyCollection<string>(_messages);
            Message = message;
            Data = data;
        }

        public IEnumerable<string> Errors { get; }

        public void AddError(string message)
        {
            _messages.Add(message);
            // return this;
        }

        public bool HasErrors { get { return _messages.Count > 0; } }

        public bool Success { get { return !HasErrors; } }

        public string Message { get; private set; }

        public object Data { get; private set; }
    }
}
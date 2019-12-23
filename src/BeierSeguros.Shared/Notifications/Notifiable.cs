using System.Collections.Generic;
using System.Linq;

namespace BeierSeguros.Shared.Notifications
{
    public class Notifiable : INotifiable
    {
        public Notifiable()
        {
            Errors = new List<NotifiableError>();
        }

        public Notifiable(string message)
        {
            Errors = new List<NotifiableError>();
            Message = message;
        }

        public Notifiable(string message, object data)
        {
            Errors = new List<NotifiableError>();
            Message = message;
            Data = data;
        }

        public Notifiable(NotifiableError error)
        {
            Errors = new List<NotifiableError>();
            Errors.Add(error);
        }

        public void AddError(NotifiableError error)
        {
            Errors.Add(error);
        }

        public void AddError(string error)
        {
            Errors.Add(new NotifiableError(error));
        }

        public void SetMessage(string message)
        {
            Message = message;
        }

        public void SetData(object data)
        {
            Data = data;
        }

        public string Message { get; private set; }

        public object Data { get; private set; }

        public IList<NotifiableError> Errors { get; private set; }

        public bool HasErrors { get { return Errors.Any(); } }

    }
}
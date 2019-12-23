namespace BeierSeguros.Shared.Notifications
{
    public class NotifiableError
    {
        public NotifiableError(string error)
        {
            Error = error;
        }

        public string Error { get; }

        public override string ToString()
        {
            return Error;
        }
    }
}
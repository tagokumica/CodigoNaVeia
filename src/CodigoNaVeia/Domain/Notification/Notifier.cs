namespace Domain.Notification
{
    public class Notifier
    {

        public Notifier(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
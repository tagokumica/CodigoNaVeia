using System.Collections.Generic;
using System.Linq;
using Domain.Interface.Notification;

namespace Domain.Notification
{
    public class Notifications: INotification
    {

        public List<Notifier> _notifiers;

        public Notifications()
        {
            _notifiers = new List<Notifier>();
        }
        public bool HaveNotifier()
        {
            return _notifiers.Any();
        }

        public List<Notifier> Get()
        {
            return _notifiers;
        }

        public void Handle(Notifier notifier)
        {
            _notifiers.Add(notifier);
        }
    }
}
using System.Collections.Generic;
using Domain.Notification;

namespace Domain.Interface.Notification
{
    public interface INotification
    {
        bool HaveNotifier();
        List<Notifier> Get();
        void Handle(Notifier notifier);
    }
}
using Domain.Interface.Notification;
using Microsoft.AspNetCore.Mvc;

namespace CodigoNaVeia.UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotification _iNotification;


        public BaseController(INotification iNotification)
        {
            _iNotification = iNotification;
        }

        public bool isValided()
        {
            return _iNotification.HaveNotifier();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Infra.CrossCutting.Security.Model;
using Microsoft.AspNetCore.Identity;
using Application.Interface;
using Domain.Interface.Notification;

namespace CodigoNaVeia.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeAppService _iEmployeeAppService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(INotification iNotification, IEmployeeAppService iEmployeeAppService, UserManager<ApplicationUser> userManager) : base(iNotification)
        {
            _iEmployeeAppService = iEmployeeAppService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

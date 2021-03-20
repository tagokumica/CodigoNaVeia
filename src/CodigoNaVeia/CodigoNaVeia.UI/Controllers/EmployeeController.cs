using System;
using Microsoft.AspNetCore.Mvc;
using Infra.CrossCutting.Security.Model;
using Microsoft.AspNetCore.Identity;
using Application.Interface;
using Application.ViewModel;
using Domain.Interface.Notification;

namespace CodigoNaVeia.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeAppService _iEmployeeAppService;
        private readonly INotification _notification;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(INotification iNotification, IEmployeeAppService iEmployeeAppService, INotification notification, UserManager<ApplicationUser> userManager) : base(iNotification)
        {
            _iEmployeeAppService = iEmployeeAppService;
            _notification = notification;
            _userManager = userManager;
        }


        [Route("atualizar-empregado/{id:guid}")]
        public IActionResult Update(Guid id)
        {

            if (id == Guid.NewGuid() || id == Guid.Empty)
            {
                return NotFound();
            }

            var employee = _iEmployeeAppService.FindById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View("Update", employee);
        }

        [Route("atualizar-empregado/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EmployeeViewModel employeeViewModel)
        {

            var user = _userManager.GetUserAsync(User);


            if (ModelState.IsValid)
            {
                _iEmployeeAppService.Insert(employeeViewModel);
                if (isValided())
                {
                    ViewBag.Notifications = _notification.Get();
                    return View(employeeViewModel);
                }
                return RedirectToAction("Index", "CompanyEmployee", new { id = user.Result.Id });

            }
            return View(employeeViewModel);
        }
    }
}


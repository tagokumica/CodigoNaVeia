using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Interface;
using Application.ViewModel;
using Domain.Interface.Notification;
using Infra.CrossCutting.Messages.MessageServices.Interface;
using Infra.CrossCutting.Security.Model;
using Microsoft.AspNetCore.Identity;

namespace CodigoNaVeia.UI.Controllers
{
    public class CompanyEmployeeController : BaseController
    {
        private readonly IEmployeeAppService _iEmployeeAppService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INotification _notification;
        private readonly ICompanyAppService _iCompanyAppService;
        private readonly IEmailService _iEmailService;

        public CompanyEmployeeController(INotification iNotification, IEmployeeAppService iEmployeeAppService, UserManager<ApplicationUser> userManager, INotification notification, ICompanyAppService iCompanyAppService, IEmailService iEmailService) : base(iNotification)
        {
            _iEmployeeAppService = iEmployeeAppService;
            _userManager = userManager;
            _notification = notification;
            _iCompanyAppService = iCompanyAppService;
            _iEmailService = iEmailService;
        }

        [HttpGet]
        public IActionResult _ListEmployees(Guid id)
        {
            var company = _iCompanyAppService.FindCompany(id);
            return PartialView("_ListEmployees", company.EmployeeViewModel);
        }

        [Route("index")]
        public IActionResult Index()
        {

            var user = _userManager.GetUserAsync(User);

            if (user.Result.Id == Guid.Empty || user.Result.Id == Guid.NewGuid())
            {
                return NotFound();
            }

            var company = _iCompanyAppService.FindCompany(user.Result.Id);

            ViewBag.ListEmployeebyCompany =
                new List<EmployeeViewModel>(_iEmployeeAppService.GetEmployeebyCompany(user.Result.Id));
           
            if (company == null)
            {
                return NotFound();
            }

            return View("Index", company);

        }


        [Route("cadastrar-empregado")]
        public IActionResult Insert()
        {
            var user = _userManager.GetUserAsync(User);
            ViewBag.EmployeeID = user.Result.Id;

            return View();
        }

        [Route("cadastrar-vendedor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Insert(EmployeeViewModel employeeViewModel)
        {

            var user = new ApplicationUser()
            {
                Name = employeeViewModel.Name,
                UserName = employeeViewModel.Email,
                Email = employeeViewModel.Email,
                NormalizedEmail = employeeViewModel.NormalizedEmail,
                NormalizedUserName = employeeViewModel.NormalizedUserName,
                ConcurrencyStamp = employeeViewModel.ConcurrencyStamp,
                Id = employeeViewModel.Id,
                PasswordHash = employeeViewModel.PasswordHash

            };

            if (ModelState.IsValid)
            {


                _iEmployeeAppService.Insert(employeeViewModel);

                if (isValided())
                {
                    ViewBag.Notifications = _notification.Get();
                    return View(employeeViewModel);
                }


                var result = await _userManager.CreateAsync(user, employeeViewModel.PasswordHash);

                var userid = _userManager.GetUserAsync(User);

                if (result.Succeeded)
                {
                    IdentityResult roles = await _userManager.AddToRoleAsync(user, "Employee");

                    IdentityResult claimId = await _userManager.AddClaimAsync(user,
                        new Claim(ClaimTypes.NameIdentifier, employeeViewModel.Id.ToString()));

                    IdentityResult claimRole =
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Employee"));

                    if (roles.Succeeded && claimId.Succeeded && claimRole.Succeeded)
                    {
                        await _iEmailService.SendEmailAsync(employeeViewModel.Email, "Conta",
                            "Sua Conta é" + employeeViewModel.Email + employeeViewModel.PasswordHash);
                    }
                }

                return RedirectToAction("Index", "CompanyEmployee", new {id = userid.Result.Id});

            }

            return View(employeeViewModel);

        }
    }
}
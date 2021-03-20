using Application.Interface;
using Application.ViewModel;
using Domain.Interface.Notification;
using Infra.CrossCutting.Messages.MessageServices.Interface;
using Infra.CrossCutting.Security.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodigoNaVeia.UI.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INotification _notification;
        private readonly ICompanyAppService _iCompanyAppService;

        public CompanyController(INotification iNotification, UserManager<ApplicationUser> userManager, INotification notification, ICompanyAppService iCompanyAppService) : base(iNotification)
        {
            _userManager = userManager;
            _notification = notification;
            _iCompanyAppService = iCompanyAppService;
        }


        [Route("index/{id:guid}")]
        public IActionResult Index(Guid id)
        {

            if (id == Guid.NewGuid() || id == Guid.Empty)
            {
                return NotFound();
            }

            var company = _iCompanyAppService.FindCompany(id);

            if (company == null)
            {
                return NotFound();
            }

            return View("Index", company);
        }


        [Route("atualizar-empresa/{id:guid}")]
        public IActionResult Update(Guid id)
        {

            if (id == Guid.NewGuid() || id == Guid.Empty)
            {
                return NotFound();
            }

            var company = _iCompanyAppService.FindbyId(id);

            if (company == null)
            {
                return NotFound();
            }

            return View("Update", company);
        }

        [Route("atualizar-empregado/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CompanyViewModel companyViewModel)
        {

            var user = _userManager.GetUserAsync(User);


            if (ModelState.IsValid)
            {
                _iCompanyAppService.Insert(companyViewModel);
                if (isValided())
                {
                    ViewBag.Notifications = _notification.Get();
                    return View(companyViewModel);
                }
                return RedirectToAction("Index", "CompanyEmployee", new { id = user.Result.Id });

            }
            return View(companyViewModel);
        }


    }
}
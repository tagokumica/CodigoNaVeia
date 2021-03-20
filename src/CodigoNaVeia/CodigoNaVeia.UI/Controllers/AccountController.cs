using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Infra.CrossCutting.Messages.MessageServices.Interface;
using Infra.CrossCutting.Security.Model;
using Infra.CrossCutting.Security.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodigoNaVeia.UI.Controllers
{
    [AllowAnonymous]
    [Route("conta")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICompanyAppService _iCompanyAppService;
        private readonly IEmailService _iEmailService;
        private readonly IEmployeeAppService _iEmployeeAppService;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<LoginViewModel> logger, UserManager<ApplicationUser> userManager, ICompanyAppService iCompanyAppService, IEmailService iEmailService, IEmployeeAppService iEmployeeAppService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _iCompanyAppService = iCompanyAppService;
            _iEmailService = iEmailService;
            _iEmployeeAppService = iEmployeeAppService;
        }



        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(User);
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);


                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");


                        if (User.IsInRole("Company"))
                        {
                            return RedirectToAction("Index", "Company", new { id = user.Result.Id});
                        }

                        if (User.IsInRole("Employee"))
                        {


                            var employee = _iEmployeeAppService.FindEmployee(user.Result.Id);

                            if (employee.Active == true)
                            {
                                return RedirectToAction("Lockout", "Account");

                            }

                            else
                            {
                                return RedirectToAction("Index", "Employee", new { id = user.Result.Id});

                            }


                        }

                    }
                }


                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }

            }

            // If we got this far, something failed, redisplay form
            return View(loginViewModel);
        }

        [Route("sair")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [Route("conta-bloqueada")]
        public IActionResult Lockout()
        {
            return View();
        }


        [Route("confirmar-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
            }

            return View();

        }

        [Route("perdi-senha")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    //return RedirectToAction("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { code },
                    protocol: Request.Scheme);

                await _iEmailService.SendEmailAsync(
                    model.Email,
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return View(model);
        }


        [Route("registrar")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("registrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CompanyViewModel companyViewModel)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser()
                {
                    Name = companyViewModel.Name,
                    UserName = companyViewModel.Email,
                    Email = companyViewModel.Email,
                    NormalizedEmail = companyViewModel.NormalizedEmail,
                    NormalizedUserName = companyViewModel.NormalizedUserName,
                    ConcurrencyStamp = companyViewModel.ConcurrencyStamp,
                    Id = companyViewModel.Id,
                    PasswordHash = companyViewModel.PasswordHash
                };

                _iCompanyAppService.Insert(companyViewModel);

                var result = await _userManager.CreateAsync(user, companyViewModel.PasswordHash);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    if (result.Succeeded)
                    {
                        IdentityResult roles =
                            await _userManager.AddToRoleAsync(user, "Company");



                        IdentityResult claimEmail =
                            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, companyViewModel.Email));

            

                        IdentityResult claimRole =
                            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Company"));


                        var claimId = await _userManager.AddClaimAsync(user,
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

                        if (roles.Succeeded && claimId.Succeeded && claimEmail.Succeeded && claimRole.Succeeded)
                        {
                            return RedirectToAction("Login", "Account");
                        }

                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(companyViewModel);
        }

    }
}
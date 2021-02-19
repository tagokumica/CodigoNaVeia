using System.ComponentModel.DataAnnotations;

namespace Infra.CrossCutting.Security.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembre-Me?")]
        public bool RememberMe { get; set; }
    }
}
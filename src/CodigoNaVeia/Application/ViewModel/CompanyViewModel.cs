using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class CompanyViewModel 
    {

        public CompanyViewModel()
        {
            Id = Guid.NewGuid();
            CompanyAddressViewModel = new List<CompanyAddressViewModel>();
            EmployeeViewModel = new List<EmployeeViewModel>();
        }

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "Nome do Proprietário")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
      
        [Display(Name = "Cnpj")]
        [DataType(DataType.Text)]
        public string Cnpj { get; set; }
 
        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string Ie { get; set; }

        [Display(Name = "Logo")]
        public IFormFile Logo { get; set; }
        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }


        public IEnumerable<CompanyAddressViewModel> CompanyAddressViewModel { get; set; }

        public IEnumerable<EmployeeViewModel> EmployeeViewModel { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Id = Guid.NewGuid();
        }

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }


        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Display(Name = "Cpf")]
        [DataType(DataType.Text)]
        public string Cpf { get; set; }
        public Guid CompanyID { get; set; }

        [Display(Name = "Rg")]
        [DataType(DataType.Text)]
        public string Rg { get; set; }

        public bool Active { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
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


        public CompanyViewModel CompanyViewModel { get; set; }

    }
}
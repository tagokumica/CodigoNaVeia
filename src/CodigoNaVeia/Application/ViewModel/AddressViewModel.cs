using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
            AddressID = Guid.NewGuid();
            CompanyAddressViewModel = new List<CompanyAddressViewModel>();
        }

        [ScaffoldColumn(false)]
        public Guid AddressID { get; set; }

        [Display(Name = "Rua")]
        [DataType(DataType.Text)]
        public string Street { get; set; }

        [Display(Name = "Número")]
        public int Number { get; set; }

        [Display(Name = "Complemento")]
        [DataType(DataType.Text)]
        public string AddressComplement { get; set; }

        [Display(Name = "Bairro")]
        [DataType(DataType.Text)]
        public string District { get; set; }

        [Display(Name = "Cidade")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Display(Name = "CEP")]
        [DataType(DataType.Text)]
        public string PostalCode { get; set; }

        [Display(Name = "Estado")]
        [DataType(DataType.Text)]
        public string FederativeUnit { get; set; }

        public IEnumerable<CompanyAddressViewModel> CompanyAddressViewModel { get; set; }

    }
}
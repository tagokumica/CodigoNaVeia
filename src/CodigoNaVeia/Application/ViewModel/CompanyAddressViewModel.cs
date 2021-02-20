using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class CompanyAddressViewModel
    {
        public CompanyAddressViewModel()
        {
            CompanyAddressID = Guid.NewGuid();
        }

        [ScaffoldColumn(false)]
        public Guid CompanyAddressID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid AddressID { get; set; }
        public AddressViewModel AddressViewModel { get; set; }
        public CompanyViewModel CompanyViewModel { get; set; }

    }
}
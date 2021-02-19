using System;

namespace Domain.Entities
{
    public class CompanyAddress
    {
        public CompanyAddress()
        {
            CompanyAddressID = Guid.NewGuid();
        }
        public Guid CompanyAddressID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid AddressID { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }

    }
}
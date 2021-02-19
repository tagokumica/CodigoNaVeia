using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Address
    {
        public Address()
        {
            AddressID = Guid.NewGuid();
            CompanyAddress = new List<CompanyAddress>();
        }
        public Guid AddressID { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string AddressComplement { get; set; }

        public string District { get; set; }

        public string City { get; set; }
        public string PostalCode { get; set; }

        public string FederativeUnit { get; set; }

        public IEnumerable<CompanyAddress> CompanyAddress { get; set; }

    }
}
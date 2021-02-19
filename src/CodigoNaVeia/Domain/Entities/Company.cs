using Infra.CrossCutting.Security.Model;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Company : ApplicationUser
    {

        public Company()
        {
            Id = Guid.NewGuid();
            CompanyAddress = new List<CompanyAddress>();
            Employee = new List<Employee>();
        }


        public string Cnpj { get; set; }

        public string Ie { get; set; }

        public string Logo { get; set; }
        public IEnumerable<CompanyAddress> CompanyAddress { get; set; }

        public IEnumerable<Employee> Employee { get; set; }

    }
}
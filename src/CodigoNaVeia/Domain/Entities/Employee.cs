using System;
using Infra.CrossCutting.Security.Model;

namespace Domain.Entities
{
    public class Employee : ApplicationUser
    {
        public Employee()
        {
            Id = Guid.NewGuid();
        }
        public string Cpf { get; set; }
        public Guid CompanyID { get; set; }
        public string Rg { get; set; }

        public bool Active { get; set; }
        public DateTime BirthDate { get; set; }

        public Company Company { get; set; }

    }
}
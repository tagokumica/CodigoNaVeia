using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interface.Repository;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CodigoNaVeiaContext context) : base(context)
        {
        }

        public IEnumerable<Employee> GetEmployeebyCompany(Guid id)
        {
            return DbSet.Where(s => s.Id == id).ToList();
        }

        public void Active(Guid id)
        {
            DbSet.Find(id).Active = true;
        }

        public void Desactive(Guid id)
        {
            DbSet.Find(id).Active = false;
        }

        public Employee FindEmployee(Guid id)
        {
            return DbSet.Include("Company").FirstOrDefault(s => s.Id == id);
        }
    }
}
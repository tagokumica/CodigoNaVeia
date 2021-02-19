using Domain.Entities;
using Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {

        public CompanyRepository(CodigoNaVeiaContext context) : base(context)
        {
        }


        public Company FindCompany(Guid id)
        {
            return DbSet.Include("CompanyAddress.Address")
                        .Include("Employee").FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Company> GetCompanybyEmployee(Guid id)
        {
            return codigoNaVeiaContext
                .Employee
                .Include("Company")
                .Where(s => s.CompanyID == id)
                .Select(s => s.Company)
                .ToList();
        }

        public void InsertAddressbyCompany(CompanyAddress companyAddress)
        {
            codigoNaVeiaContext.Set<CompanyAddress>().Add(companyAddress);
        }
    }
}
using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface ICompanyRepository: IRepository<Company>
    {
       IEnumerable<Company> GetCompanybyEmployee(Guid id);
       Company FindCompany(Guid id);
       void InsertAddressbyCompany(CompanyAddress companyAddress);
    }
}
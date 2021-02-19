using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interface.Service
{
    public interface ICompanyService: IDisposable
    {
        IEnumerable<Company> GetCompanybyEmployee(Guid id);
        Company FindCompany(Guid id);
        Company Insert(Company company);
        Company Update(Company company);
        Company FindbyId(Guid id);
        void InsertAddressbyCompany(CompanyAddress companyAddress);

    }
}
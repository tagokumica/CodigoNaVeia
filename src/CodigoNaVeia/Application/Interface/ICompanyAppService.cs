using System;
using System.Collections.Generic;
using Application.ViewModel;

namespace Application.Interface
{
    public interface ICompanyAppService: IDisposable
    {
        IEnumerable<CompanyViewModel> GetCompanybyEmployee(Guid id);
        CompanyViewModel FindCompany(Guid id);
        CompanyViewModel Insert(CompanyViewModel companyViewModel);
        CompanyViewModel Update(CompanyViewModel companyViewModel);
        CompanyViewModel FindbyId(Guid id);
        void InsertAddressbyCompany(CompanyAddressViewModel companyAddressViewModel);

    }
}
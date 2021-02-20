using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Interface.Service;
using System;
using System.Collections.Generic;
using Domain.Entities;
using Infra.Data.UnitOfWork;

namespace Application.Service
{
    public class CompanyAppService: BaseAppService, ICompanyAppService
    {
        private readonly ICompanyService _iCompanyService;
        private readonly IMapper _iMapper;

        public CompanyAppService(IUnitOfWork uow, ICompanyService iCompanyService, IMapper iMapper) : base(uow)
        {
            _iCompanyService = iCompanyService;
            _iMapper = iMapper;
        }


        public void Dispose()
        {
            _iCompanyService.Dispose();
            GC.SuppressFinalize(this);
        }

        public CompanyViewModel FindbyId(Guid id)
        {
            return _iMapper.Map<CompanyViewModel>(_iCompanyService.FindbyId(id));
        }

        public CompanyViewModel FindCompany(Guid id)
        {
            return _iMapper.Map<CompanyViewModel>(_iCompanyService.FindCompany(id));
        }

        public IEnumerable<CompanyViewModel> GetCompanybyEmployee(Guid id)
        {
            return _iMapper.Map<IEnumerable<CompanyViewModel>>(_iCompanyService.GetCompanybyEmployee(id));
        }

        public CompanyViewModel Insert(CompanyViewModel companyViewModel)
        {
            var company = _iMapper.Map<Company>(companyViewModel);

            var companyReturn = _iCompanyService.Insert(company);
            base.Commit();
            return _iMapper.Map<CompanyViewModel>(companyReturn);
        }

        public void InsertAddressbyCompany(CompanyAddressViewModel companyAddressViewModel)
        {
            try
            {
                var companyAddress = _iMapper.Map<CompanyAddress>(companyAddressViewModel);
                _iCompanyService.InsertAddressbyCompany(companyAddress);
                base.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CompanyViewModel Update(CompanyViewModel companyViewModel)
        {
            var company = _iMapper.Map<Company>(companyViewModel);

            var companyReturn = _iCompanyService.Update(company);
            base.Commit();
            return _iMapper.Map<CompanyViewModel>(companyReturn);
        }
    }
}
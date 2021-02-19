using Domain.Entities;
using Domain.Interface.Service;
using System;
using System.Collections.Generic;
using Domain.Entities.Validation;
using Domain.Interface.Notification;
using Domain.Interface.Repository;
using System.Linq;

namespace Domain.Service
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly ICompanyRepository _iCompanyRepository;
        private readonly IEmployeeRepository _iEmployeeRepository;

        public CompanyService(INotification iNotification, ICompanyRepository iCompanyRepository, IEmployeeRepository iEmployeeRepository) : base(iNotification)
        {
            _iCompanyRepository = iCompanyRepository;
            _iEmployeeRepository = iEmployeeRepository;
        }
        public void Dispose()
        {
            _iCompanyRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Company FindbyId(Guid id)
        {
            return _iCompanyRepository.FindbyId(id);
        }

        public Company FindCompany(Guid id)
        {
            return _iCompanyRepository.FindCompany(id);
        }

        public IEnumerable<Company> GetCompanybyEmployee(Guid id)
        {
            return _iCompanyRepository.GetCompanybyEmployee(id);
        }

        public Company Insert(Company company)
        {


            if (!ExecuteValidation(new CompanyValidation(), company))
                return company;


            if (_iCompanyRepository.Search(s => s.Cnpj == company.Cnpj && s.Id != company.Id).Any())
            {
                Notify("Já Existe um CNPJ com este Número");
            }

            if (_iCompanyRepository.Search(s => s.Ie == company.Ie && s.Id != company.Id).Any())
            {
                Notify("Já Existe uma Inscrição Estadual com este Número");
            }

            if (_iCompanyRepository.Search(s => s.Email == company.Email && s.Id != company.Id).Any() ||
                _iEmployeeRepository.Search(s => s.Email == company.Email).Any())
            {
                Notify("Já Existe um Email ");
            }

            if (!IsValid()) return company;


            return _iCompanyRepository.Insert(company);
        }

        public void InsertAddressbyCompany(CompanyAddress companyAddress)
        {
            _iCompanyRepository.InsertAddressbyCompany(companyAddress);
        }

        public Company Update(Company company)
        {
            if (_iCompanyRepository.Search(s => s.Email == company.Email && s.Id != company.Id).Any() ||
                _iEmployeeRepository.Search(s => s.Email == company.Email).Any())
            {
                Notify("Já Existe um Email ");
            }

            if (!IsValid()) return company;


            return _iCompanyRepository.Update(company);
        }
    }
}
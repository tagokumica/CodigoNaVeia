using Domain.Entities;
using Domain.Interface.Notification;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Validation;

namespace Domain.Service
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly ICompanyRepository _iCompanyRepository;
        private readonly IEmployeeRepository _iEmployeeRepository;

        public EmployeeService(INotification iNotification, ICompanyRepository iCompanyRepository, IEmployeeRepository iEmployeeRepository) : base(iNotification)
        {
            _iCompanyRepository = iCompanyRepository;
            _iEmployeeRepository = iEmployeeRepository;
        }

        public void Active(Guid id)
        {
            _iEmployeeRepository.Active(id);
        }

        public void Desactive(Guid id)
        {
            _iEmployeeRepository.Desactive(id);
        }

        public void Dispose()
        {
            _iEmployeeRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Employee FindById(Guid id)
        {
            return _iEmployeeRepository.FindbyId(id);
        }

        public Employee FindEmployee(Guid id)
        {
            return _iEmployeeRepository.FindEmployee(id);
        }

        public IEnumerable<Employee> GetEmployeebyCompany(Guid id)
        {
            return _iEmployeeRepository.GetEmployeebyCompany(id);
        }

        public Employee Insert(Employee employee)
        {
            if (!ExecuteValidation(new EmployeeValidation(), employee))
                return employee;


            if (_iEmployeeRepository.Search(s => s.Cpf == employee.Cpf && s.Id != employee.Id).Any())
                Notify("Já Existe um CPF com este Número");


            if (_iEmployeeRepository.Search(s => s.Rg == employee.Rg && s.Id != employee.Id).Any())
                Notify("Já Existe um RG com este Número");


            if (_iEmployeeRepository.Search(s => s.Email == employee.Email && s.Id != employee.Id).Any() ||
                _iCompanyRepository.Search(s => s.Email == employee.Email).Any())
                Notify("Já Existe um Email ");

            if (!IsValid()) return employee;

            return _iEmployeeRepository.Insert(employee);
        }

        public IEnumerable<Employee> Search(string searching)
        {
            return _iEmployeeRepository.Search(s => s.Email.Contains(searching));
        }

        public Employee Update(Employee employee)
        {
            if (_iEmployeeRepository.Search(s => s.Email == employee.Email && s.Id != employee.Id).Any() ||
                _iCompanyRepository.Search(s => s.Email == employee.Email).Any())
                Notify("Já Existe um Email ");

            if (!IsValid()) return employee;

            return _iEmployeeRepository.Update(employee);
        }
    }
}
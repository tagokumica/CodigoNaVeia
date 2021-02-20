using System;
using System.Collections.Generic;
using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Entities;
using Domain.Interface.Service;
using Infra.Data.UnitOfWork;

namespace Application.Service
{
    public class EmployeeAppService: BaseAppService, IEmployeeAppService
    {

        private readonly IEmployeeService _iEmployeeService;
        private readonly IMapper _iMapper;

        public EmployeeAppService(IUnitOfWork uow, IEmployeeService iEmployeeService, IMapper iMapper) : base(uow)
        {
            _iEmployeeService = iEmployeeService;
            _iMapper = iMapper;
        }
        public void Dispose()
        {
            _iEmployeeService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<EmployeeViewModel> GetEmployeebyCompany(Guid id)
        {
            return _iMapper.Map<IEnumerable<EmployeeViewModel>>(_iEmployeeService.GetEmployeebyCompany(id));
        }

        public void Active(Guid id)
        {
            try
            {
                _iEmployeeService.Active(id);
                base.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Desactive(Guid id)
        {
            try
            {
                _iEmployeeService.Desactive(id);
                base.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployeeViewModel FindEmployee(Guid id)
        {
            return _iMapper.Map<EmployeeViewModel>(_iEmployeeService.FindEmployee(id));
        }

        public EmployeeViewModel Insert(EmployeeViewModel employeeViewModel)
        {
            var employee = _iMapper.Map<Employee>(employeeViewModel);

            var employeeReturn = _iEmployeeService.Insert(employee);
            base.Commit();
            return _iMapper.Map<EmployeeViewModel>(employeeReturn);
        }

        public EmployeeViewModel Update(EmployeeViewModel employeeViewModel)
        {
            var employee = _iMapper.Map<Employee>(employeeViewModel);

            var employeeReturn = _iEmployeeService.Update(employee);
            base.Commit();
            return _iMapper.Map<EmployeeViewModel>(employeeReturn);
        }

        public EmployeeViewModel FindById(Guid id)
        {
            return _iMapper.Map<EmployeeViewModel>(_iEmployeeService.FindById(id));
        }

        public IEnumerable<EmployeeViewModel> Search(string searching)
        {
            return _iMapper.Map<IEnumerable<EmployeeViewModel>>(_iEmployeeService.Search(searching));
        }
    }
}
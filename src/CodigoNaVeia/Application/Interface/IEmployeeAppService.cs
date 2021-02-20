using System;
using System.Collections.Generic;
using Application.ViewModel;

namespace Application.Interface
{
    public interface IEmployeeAppService: IDisposable
    {
        IEnumerable<EmployeeViewModel> GetEmployeebyCompany(Guid id);
        void Active(Guid id);
        void Desactive(Guid id);
        EmployeeViewModel FindEmployee(Guid id);
        EmployeeViewModel Insert(EmployeeViewModel employeeViewModel);
        EmployeeViewModel Update(EmployeeViewModel employeeViewModel);
        EmployeeViewModel FindById(Guid id);
        IEnumerable<EmployeeViewModel> Search(string searching);
    }
}
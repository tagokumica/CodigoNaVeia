using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interface.Service
{
    public interface IEmployeeService: IDisposable
    {
        IEnumerable<Employee> GetEmployeebyCompany(Guid id);
        void Active(Guid id);
        void Desactive(Guid id);
        Employee FindEmployee(Guid id);
        Employee Insert(Employee employee);
        Employee Update(Employee employee);
        Employee FindById(Guid id);
        IEnumerable<Employee> Search(string searching);
    }
}
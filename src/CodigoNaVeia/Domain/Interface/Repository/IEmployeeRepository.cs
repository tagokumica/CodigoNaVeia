using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeebyCompany(Guid id);
        void Active(Guid id);
        void Desactive(Guid id);
        Employee FindEmployee(Guid id);


    }
}
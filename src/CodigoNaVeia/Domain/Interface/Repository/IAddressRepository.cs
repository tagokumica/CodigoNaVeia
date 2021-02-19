using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IAddressRepository: IRepository<Address>
    {
        IEnumerable<Address> GetAddressbyCompany(Guid id);

    }
}
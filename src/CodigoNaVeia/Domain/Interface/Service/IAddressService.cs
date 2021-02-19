using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interface.Service
{
    public interface IAddressService: IDisposable
    {
        Address Insert(Address address);
        Address Update(Address address);
        Address FindbyId(Guid id);
        IEnumerable<Address> Search(string searching);
        IEnumerable<Address> GetAddressbyCompany(Guid id);

    }
}
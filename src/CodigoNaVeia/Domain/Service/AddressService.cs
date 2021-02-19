using Domain.Entities;
using Domain.Interface.Service;
using System;
using System.Collections.Generic;
using Domain.Interface.Repository;

namespace Domain.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _iAddressRepository;

        public AddressService(IAddressRepository iAddressRepository)
        {
            _iAddressRepository = iAddressRepository;
        }
        public void Dispose()
        {
            _iAddressRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Address FindbyId(Guid id)
        {
            return _iAddressRepository.FindbyId(id);
        }

        public IEnumerable<Address> GetAddressbyCompany(Guid id)
        {
            return _iAddressRepository.GetAddressbyCompany(id);
        }

        public Address Insert(Address address)
        {
            return _iAddressRepository.Insert(address);
        }

        public IEnumerable<Address> Search(string searching)
        {
            return _iAddressRepository.Search(c => c.Street.Contains(searching));
        }

        public Address Update(Address address)
        {
            return _iAddressRepository.Update(address);
        }
    }
}
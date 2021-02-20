using System;
using System.Collections.Generic;
using Application.ViewModel;

namespace Application.Interface
{
    public interface IAddressAppService: IDisposable
    {
        AddressViewModel Insert(AddressViewModel addressViewModel);
        AddressViewModel Update(AddressViewModel addressViewModel);
        AddressViewModel FindbyId(Guid id);
        IEnumerable<AddressViewModel> Search(string searching);
        IEnumerable<AddressViewModel> GetAddressbyCompany(Guid id);

    }
}
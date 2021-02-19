using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interface.Repository;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(CodigoNaVeiaContext context) : base(context)
        {
        }

        public IEnumerable<Address> GetAddressbyCompany(Guid id)
        {
            return codigoNaVeiaContext
                .CompanyAddress
                .Include("Address")
                .Where(s => s.CompanyID == id)
                .Select(s => s.Address)
                .ToList();
        }
    }
}
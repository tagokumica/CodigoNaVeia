using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class CompanyAddressMapping : IEntityTypeConfiguration<CompanyAddress>
        {
            public void Configure(EntityTypeBuilder<CompanyAddress> builder)
            {
                builder.HasKey(s => s.CompanyAddressID);

                builder.HasOne(s => s.Company)
                    .WithMany(s => s.CompanyAddress)
                    .HasForeignKey(s => s.CompanyID);

                builder.HasOne(s => s.Address)
                    .WithMany(s => s.CompanyAddress)
                    .HasForeignKey(s => s.AddressID);


                builder.ToTable("CompanyAddress");

            }
        }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(s => s.AddressID);


            builder.Property(s => s.Street)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(s => s.Number)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(s => s.AddressComplement)
                .IsRequired(false)
                .HasColumnType("varchar(50)");

            builder.Property(s => s.District)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(s => s.City)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(s => s.FederativeUnit)
                .IsRequired()
                .HasColumnType("varchar(25)");


            builder.Property(s => s.PostalCode)
                .IsRequired()
                .HasColumnType("varchar(9)");


            builder.ToTable("Address");
        }

   
    }
}
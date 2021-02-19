using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(s => s.Id);


            builder.Property(s => s.Cnpj)
                .IsRequired()
                .HasColumnName("Cnpj")
                .HasColumnType("varchar(14)");



            builder.Property(s => s.Ie)
                .IsRequired()
                .HasColumnName("Ie")
                .HasColumnType("varchar(14)");




            builder.Property(s => s.Logo)
                .IsRequired()
                .HasColumnName("Ie")
                .HasColumnType("varchar(max)");


            builder.ToTable("Company");

        }
    }

}
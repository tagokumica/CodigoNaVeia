using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(s => s.Id);



            builder.Property(s => s.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)");

            builder.Property(s => s.Rg)
                .IsRequired()
                .HasColumnName("Rg")
                .HasColumnType("varchar(13)");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(s => s.Active)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(s => s.BirthDate)
                .IsRequired()
                .HasColumnType("date");


            builder.Property(s => s.Email)
                .IsRequired()
                .HasColumnType("varchar(40)");
      
            builder.HasOne(s => s.Company)
                .WithMany(s => s.Employee)
                .HasForeignKey(s => s.CompanyID);


            builder.ToTable("Employee");
        }
    }
}
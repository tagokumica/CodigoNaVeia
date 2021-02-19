using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class CodigoNaVeiaContext : DbContext
    {
        public CodigoNaVeiaContext(DbContextOptions<CodigoNaVeiaContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address>  Address{ get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyAddress> CompanyAddress { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodigoNaVeiaContext).Assembly);

            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
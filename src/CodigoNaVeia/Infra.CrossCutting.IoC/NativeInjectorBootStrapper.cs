using Application.Interface;
using Application.Service;
using Domain.Interface.Notification;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Domain.Notification;
using Domain.Service;
using Infra.CrossCutting.Messages.MessageServices.Interface;
using Infra.CrossCutting.Messages.MessageServices.Service;
using Infra.CrossCutting.Security.Context;
using Infra.CrossCutting.Security.Model;
using Infra.Data.Context;
using Infra.Data.Repository;
using Infra.Data.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(IServiceCollection service)
        {
            service.AddScoped<ICompanyRepository, CompanyRepository>();
            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<ICompanyAppService, CompanyAppService>();

            service.AddScoped<IAddressRepository, AddressRepository>();
            service.AddScoped<IAddressService, AddressService>();
            service.AddScoped<IAddressAppService, AddressAppService>();

            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IEmployeeAppService, EmployeeAppService>();



            service.AddScoped<CodigoNaVeiaContext>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<ApplicationDbContext>();

            service.AddScoped<INotification, Notifications>();

            service.AddScoped<UserManager<ApplicationUser>>();


            service.AddScoped<IEmailService, EmailService>();

            return service;
        }


    }
}

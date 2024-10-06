using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.Management.Persistence.Reponsitory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HR.Management.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagenmentDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString")));

            services.AddScoped(typeof(IGenericReponsitory<>), typeof(GenericReponsitory<>));

            services.AddScoped<ILeaveTypeReponsitory, LeaveTypeReponsitory>();
            services.AddScoped<ILeaveAllocationReponsitory, LeaveAllowcationReponsitory>();
            services.AddScoped<ILeaveRequestReponsitory, LeaveRequestReponsitory>();

            return services;
        }
    }
}

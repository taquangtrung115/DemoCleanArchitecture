using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.Reponsitories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagenmentDBContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("LeaveManagementConnectionString")));


            services.AddScoped(typeof(IGenericReponsitory<>), typeof(GenericReponsitory<>));

            services.AddScoped<ILeaveTypeReponsitory, LeaveTypeReponsitory>();
            services.AddScoped<ILeaveRequestReponsitory, LeaveRequestReponsitory>();
            services.AddScoped<ILeaveAllocationReponsitory, LeaveAllowcationReponsitory>();

            return services;
        }
    }
   
}

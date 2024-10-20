using HR.LeaveManagement.MVC.Services;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:7056"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<ILeaveAllowcationService, LeaveAllowcationService>();
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();

            services.AddSingleton<ILocalStorageService, LocalStorageService>();

            services.AddControllersWithViews();
        }
    }
}
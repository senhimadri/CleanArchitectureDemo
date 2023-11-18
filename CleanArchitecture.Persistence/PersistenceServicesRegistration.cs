using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<LeaveManagmentDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString")));


        services.AddScoped<IUnitofWork, UnitofWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();



        return services;
    }
}

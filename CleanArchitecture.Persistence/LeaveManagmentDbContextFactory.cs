using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace CleanArchitecture.Persistence;

public class LeaveManagmentDbContextFactory : IDesignTimeDbContextFactory<LeaveManagmentDbContext>
{
    public LeaveManagmentDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        var builder = new DbContextOptionsBuilder<LeaveManagmentDbContext>();

        var connectionString = configuration.GetConnectionString("LeaveManagementConnectionString");

        builder.UseSqlServer(connectionString);

        return new LeaveManagmentDbContext(builder.Options);
    }
}

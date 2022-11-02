using BMH.DAL;
using BMH.Repository;
using BMH.Repository.Interfaces;
using BMH.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string? sqlServer = Environment.GetEnvironmentVariable("SqlConnectionString");

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddDbContext<BMHContext>(
            options =>
            {
                options.UseSqlServer(sqlServer);
                options.EnableSensitiveDataLogging();
            });
        services.AddSingleton<IHouseService, HouseService>();
        services.AddSingleton<ICustomerService, CustomerService>();
        services.AddScoped<IHouseRepository, HouseRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    })
    .Build();

host.Run();

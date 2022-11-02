using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Interface;
using Service;
using Service.Interface;

string? sqlServer = Environment.GetEnvironmentVariable("SqlConnectionString");

IHost? host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddDbContext<BmhContext>(
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

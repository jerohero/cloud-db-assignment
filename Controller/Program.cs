using BMH.DAL;
using BMH.Repository;
using BMH.Repository.Interfaces;
using BMH.Service;
using BMH.Service.Interfaces;
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
        services.AddScoped<IHouseRepository, HouseRepository>();
    })
    .Build();

host.Run();
host.Run();
